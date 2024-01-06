﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFVkontakte.View;
using WPFVkontakte.Model.VkUser;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WPFVkontakte.Model.VkWall;
using WPFVkontakte.Core;
using System.Threading.Tasks;
using System.Web;
using WPFVkontakte.Model.VkGroup;
using WPFVkontakte.Model.VkWall;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using WPFVkontakte.Utility.VkUtility;
using WPFVkontakte.Utility;
using WPFVkontakte;
using System.Windows.Input;
using System.Windows.Media;
using WPFVkontakte.Utility;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace WPFVkontakte.ViewModel
{
    public class PolyticViewModel : INotifyPropertyChanged
    {
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

        public PolyticViewModel()
        {
            FindPosts = new MyCommand(GetAll);
            Posts = new ObservableCollection<Item>();
        }
        private async void GetAll(object obj)
        {
            Posts.Clear();
            foreach (string s in CategoriesViewModel.Polytic)
            {
                var res = await Utility.VkUtility.Requests.FetchWallInfo(s);
                if (res.response.response != null)
                {
                    //ResponseContent = Utility.PrettyJson(res.rawContent);
                    foreach (var post in res.response.response.items)
                    {
                        if (post.post_source.type != "vk" && post.attachments != null && post.attachments.Any() && post.copy_history == null && post.attachments[0].type != "video")
                        {
                            if (post.attachments[0].photo != null)
                            {
                                if (post.attachments[0].photo.sizes[2].url != null)
                                {
                                    post.Image1 = post.attachments[0].photo.sizes[2].url;

                                    Posts.Add(post);
                                }
                            }
                            else
                            {
                                post.Image1 = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjqU18mugITQk-OJ4m5bSDUgUOaXGr-XZFjjJXaeIt6F6lNvVYUhd5HdjiVbCiGn1rXgs&usqp=CAU";
                                Posts.Add(post);
                            }
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


