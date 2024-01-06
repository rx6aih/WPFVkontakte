using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFVkontakte.Model.VkGroup;
namespace WPFVkontakte.Model.VkUser
{
    public class User
    {
        public int id { get; set; }
        public ICollection<Group>? groups { get; set; }
    }
}
