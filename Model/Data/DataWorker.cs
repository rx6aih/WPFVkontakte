using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFVkontakte.Model.VkUser;
using WPFVkontakte.Model.VkGroup;
using WPFVkontakte.Utility.VkUtility;
using Microsoft.IdentityModel.Tokens;

namespace WPFVkontakte.Model.Data
{
    public static class DataWorker
    {
        public static string AddUser(int Id) //добавление пользователя в бд
        {
            string result = "Пользователь с таким id уже есть в базе данных";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.Users.Any(usr => usr.id == Id);

                if (!checkIsExist)
                {
                    User newUser = new User { id = Id };
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    result = "Новый пользователь";
                }
                return result;
            }
        }

        public static string AddGroup(int Id,string Name,string Screen_name,
            string Photo_50,string Photo_100,string Photo_200) //добавление группы в бд
        {
            string result = "Группа с таким Id уже есть";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.Groups.Any(grp => grp.id == Id);

                if (!checkIsExist)
                {
                    Group newGroup = new Group {
                        id = Id,
                        name = Name,
                        screen_name = Screen_name,
                        photo_50= Photo_50,
                        photo_100= Photo_100,
                        photo_200= Photo_200
                    };
                    db.Groups.Add(newGroup);
                    db.SaveChanges();
                    result = "Новая группа";
                }
                return result;
            }

        }
        public static List<Group> UserGroups(int Id) // поиск в бд групп конкретного пользователя
        {
            List<Group> userGroups = new List<Group>();
            using (ApplicationContext db=new ApplicationContext())
            {
                    foreach(Group grp in db.Groups)
                    {
                        if(grp.UserId.Any(usr=>usr.id==Id))
                        userGroups.Add(grp);
                    }
            }
            return userGroups;
        }
    }
}
