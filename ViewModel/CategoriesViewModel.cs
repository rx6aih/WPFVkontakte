using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFVkontakte.Core;

namespace WPFVkontakte.ViewModel
{
    class CategoriesViewModel
    {
        public static List<string> Polytic = new List<string> { "nws_ru", "ria", "lentach", "kommersant.economics", "channel78news", "ikakprosto" };
        public static List<string> Sport=new List<string>() { "mma", "olympicsrus", "russianbiathlon", "moscowmarathon", "matchtv", "sport24_ru", "sportsru" };
        public static List<string> Games= new List<string>() { "playgame", "dota_2_international_2023", "studanal", "gamenavigator", "dota2", "igromania" }; 
    }
}
