using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFVkontakte.Core;

namespace WPFVkontakte.ViewModel
{
    class MainViewModel :ObservableObject
    {
        public RelayComand PopularViewComand { get; set; }
        public RelayComand UserGroupsViewComand { get; set; }


        public RelayComand SportViewComand { get; set; }
        public RelayComand GamesViewComand { get; set; }
        public RelayComand PolyticViewComand { get; set; }


        public PopularViewModel PopularVM { get; set; }
        public UserGroupsViewModel UserGroupsVM { get; set; }


        public GamesViewModel GamesVM { get; set; }
        public PolyticViewModel PolyticVM { get; set; }
        public SportViewModel SportVM { get; set; }

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; 
                  OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            PopularVM=new PopularViewModel();
            UserGroupsVM=new UserGroupsViewModel();

            GamesVM=new GamesViewModel();
            PolyticVM=new PolyticViewModel();
            SportVM=new SportViewModel();

            CurrentView = PopularVM;

            PopularViewComand = new RelayComand(o =>
            {
                CurrentView = PopularVM;
            }); 
            UserGroupsViewComand = new RelayComand(o =>
            {
                CurrentView = UserGroupsVM;
            });

            SportViewComand = new RelayComand(o =>
            {
                CurrentView = SportVM;
            });
            GamesViewComand = new RelayComand(o =>
            {
                CurrentView = GamesVM;
            });
            PolyticViewComand = new RelayComand(o =>
            {
                CurrentView = PolyticVM;
            });
        }
    }
}
