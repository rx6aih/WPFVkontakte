using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WPFVkontakte.Model.VkWall;
using WPFVkontakte.Core;
using WPFVkontakte.Model.VkGroup;

namespace WPFVkontakte.ViewModel
{
    class UserGroupsViewModel : INotifyPropertyChanged
    {
        private string _inputText;
        public string InputText
        {
            get { return _inputText; }
            set
            {
                if (_inputText != value)
                {
                    _inputText = value;
                    OnPropertyChanged(nameof(InputText));
                }
            }
        }

        private ObservableCollection<Item> _posts;
        public ObservableCollection<Item> Posts
        {
            get { return _posts; }
            set
            {
                _posts = value;
                OnPropertyChanged(nameof(Posts));
            }
        }

        public RelayComand FindPosts { get; set; }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public UserGroupsViewModel()
        {
            FindPosts = new RelayComand(GetAll,CanExecute);
            Posts = new ObservableCollection<Item>();
        }
        
        private async void GetAll(object obj)
        {
            Posts.Clear();
            //получение id пользователя
            var preId = await Utility.VkUtility.Requests.FetchUserId(InputText);
            
            //предварительная проверка на правильость id
            if (preId.response.response == null || InputText==null) 
                MessageBox.Show("Вы не ввели Id!");
            else if (preId.response.response.Any()&&preId.response.response[0].is_closed == true) 
                MessageBox.Show("Данный профель закрыт");
            else
            {
                string Id = preId.response.response[0].id.ToString();
                //запрос по полученному id на сервер
                var preGroupsList = await Utility.VkUtility.Requests.FetchUserInfo(Id);

                List<Group> groupList = new List<Group>();

                //дополнительные проверки
                if (preGroupsList.response.response == null) 
                    MessageBox.Show("Неправильный Id!");
                else if (preGroupsList.response.response.count == 0) 
                    MessageBox.Show("Данный человек не вступил ни в одну группу");
                else
                {
                    //добавление в список групп только открытых сообществ
                    foreach (var group in preGroupsList.response.response.items)
                        if (group.is_closed == 0)
                                groupList.Add(group);  
                    //очистка списка
                    Posts.Clear();
                    //добавление постов, прошедших фильтарцию, в итоговый список
                    foreach (Group group in groupList)
                    {
                        var res = await Utility.VkUtility.Requests.FetchWallInfo(group.screen_name);
                        if (res.response.response != null)
                        {
                            foreach (var post in res.response.response.items)
                            {
                                if (post.post_source.type != "vk" && post.attachments != null && post.attachments.Any() && post.copy_history == null && post.attachments[0].type != "video")
                                {
                                    if (post.attachments[0].photo != null && post.attachments[0].photo.sizes[2].url != null)
                                    {
                                        post.Image1 = post.attachments[0].photo.sizes[2].url;
                                        post.GroupPhoto_50 = group.photo_50;
                                        post.GroupScreen_name = group.screen_name;

                                        Posts.Add(post);
                                    }
                                    else
                                    {
                                        post.GroupPhoto_50 = group.photo_50;
                                        post.GroupScreen_name = group.screen_name;
                                        post.Image1 = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjqU18mugITQk-OJ4m5bSDUgUOaXGr-XZFjjJXaeIt6F6lNvVYUhd5HdjiVbCiGn1rXgs&usqp=CAU";
                                        
                                        Posts.Add(post);
                                    }
                                }

                            }
                        }
                    }
                    //сортировка итогового списка по количеству лайков
                    for (int i = 0; i < Posts.Count; i++)
                    {
                        for (int j = 0; j < Posts.Count - 1 - i; j++)
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
    }
}
