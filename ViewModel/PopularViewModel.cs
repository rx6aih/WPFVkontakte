using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using WPFVkontakte.Model.VkWall;
using WPFVkontakte.Core;

namespace WPFVkontakte.ViewModel
{
    public class PopularViewModel:INotifyPropertyChanged
    {
        List<string> groupList = new List<string>() 
        { "men", "motor", "poet_omar", "anekdot", "v5inf", "sarkazmcorp", "hmideas"
            , "zloyzayacgif", "pubauto", "knows", "beginenglish_ru", "velikieslova"
            , "fakt1", "footballru", "rhymes", "tvoicomicsi", "reddit", "dobriememes"
            , "styd.pozor" };

        private ObservableCollection<Item> _posts;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Item> Posts
        {
            get { return _posts; }
            set
            {
                _posts = value;
                OnPropertyChanged(nameof(Posts));
            }
        }
        public MyCommand FindPosts { get; }

        public PopularViewModel()
        {
            FindPosts = new MyCommand(GetAll);
            Posts = new ObservableCollection<Item>();
        }
        private async void GetAll(object obj)
        {
            Posts.Clear();
            foreach (string s in groupList)
            {
                var res = await Utility.VkUtility.Requests.FetchWallInfo(s);
                if (res.response.response != null)
                {
                    foreach (var post in res.response.response.items)
                    {
                        if (post.attachments != null && post.attachments.Any())
                        {
                            if (post.copy_history == null && post.attachments[0].type != "video")
                            {
                                if (post.attachments[0].photo != null)
                                {
                                    if (post.attachments[0].photo.sizes[2].url != null&& post.text.Length<100)
                                    {
                                        post.Image1 = post.attachments[0].photo.sizes[2].url;

                                        Posts.Add(post);
                                    }
                                }
                            }
                        }
                        else if (post.text.Length >1 &&post.text.Length<100)
                        {
                            post.Image1 = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjqU18mugITQk-OJ4m5bSDUgUOaXGr-XZFjjJXaeIt6F6lNvVYUhd5HdjiVbCiGn1rXgs&usqp=CAU";
                            Posts.Add(post);
                        }

                    }
                }
            }
            for (int i = 0; i < Posts.Count; i++)
            {
                for (int j = 0; j < Posts.Count - 1-i; j++)
                    if (Posts[i].likes.count < Posts[j].likes.count)
                    {
                        var temp = Posts[i];
                        Posts[i] = Posts[j];
                        Posts[j] = temp;
                    }
            }
        }
    }
}
