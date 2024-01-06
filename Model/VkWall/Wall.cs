using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFVkontakte.Model.VkWall
{
    public class Wall // массив постов и поле count 
    {
        public Item[] items { get; set; }
        public int count { get; set; }
    }
}
