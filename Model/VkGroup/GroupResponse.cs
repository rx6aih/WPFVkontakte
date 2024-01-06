using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFVkontakte.Model.VkGroup
{
    public class GroupResponse //ответ с информацией о группах пользователе вместе с полем count(количество групп всего)
    {
        public int count { get; set; }
        public Group[]? items { get; set; }
    }
}
