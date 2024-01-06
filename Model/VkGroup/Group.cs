using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFVkontakte.Model.VkUser;

namespace WPFVkontakte.Model.VkGroup
{
    public class Group 
    {
        public ICollection<User>? UserId { get; set; }
        public int id { get; set; }
        public string? name { get; set; }
        public string? screen_name { get; set; }
        public int is_closed { get; set; }
        public string? type { get; set; }
        public string? photo_50 { get; set; }
        public string? photo_100 { get; set; }
        public string? photo_200 { get; set; }
    }
}
