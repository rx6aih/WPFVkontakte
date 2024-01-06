using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using WPFVkontakte.Model.VkGroup;
using WPFVkontakte.Model.VkUser;
using WPFVkontakte.Model.VkWall;

namespace WPFVkontakte.Utility.VkUtility
{
    public class Response<T> //объект с данными
    {
        //сырой json
        public string? rawContent { get; set; } 
        //ответ, десериализованный под нужный класс
        public T? response { get; set; } 
    }



    public class Requests
    {
        private static string ACCESS_TOKEN = "0d61b1600d61b1600d61b160430e747cdf00d610d61b1606879ef1610589ff24ae99a37";
        private static string Version = "5.154";

        private static HttpClient client = new HttpClient();

        //построение запроса с помощью querybuilder
        public static Task<HttpResponseMessage> VKGet(string method, Dictionary<string, string> param)
        {
            var builder = new UriBuilder($"https://api.vk.com/method/{method}");
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["access_token"] = ACCESS_TOKEN;
            query["v"] = Version;

            foreach (var key in param.Keys)
            {
                query[key] = param[key];
            }
            builder.Query = query.ToString();
            string url = builder.ToString();
            return client.GetAsync(url);
        }

        public static string PrettyJson(string unPrettyJson) //метод для преобразования файла формата json в более читабельный вид для будущей отладки
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            var jsonElement = JsonSerializer.Deserialize<JsonElement>(unPrettyJson);

            return JsonSerializer.Serialize(jsonElement, options);
        }
        public static async Task<Response<UserIdFinal>> FetchUserId(string userId) //метод изменённого пользователем Id
        {
            HttpResponseMessage response = await VKGet("users.get", new Dictionary<string, string>
            {
                ["user_ids"] = userId,
            });
            var content = await response.Content.ReadAsStringAsync();
            var txt = PrettyJson(content);
            var itemsResponse = JsonSerializer.Deserialize<UserIdFinal>(content);
            return new Response<UserIdFinal>
            {
                response = itemsResponse,
                rawContent = content
            };
        }
        public static async Task<Response<GroupResponseFinal>> FetchUserInfo(string userId) //метод для получения данных о подписках пользователя
        {
            HttpResponseMessage response = await VKGet("users.getSubscriptions", new Dictionary<string, string>
            {
                ["user_id"] = userId,
               // ["count"]="3",
                ["extended"] = "1",
            });
            var content = await response.Content.ReadAsStringAsync();
            var txt = PrettyJson(content);
            var itemsResponse = JsonSerializer.Deserialize<GroupResponseFinal>(content);
            return new Response<GroupResponseFinal>
            {
                response = itemsResponse,
                rawContent = content
            };
        }

        //получение данных о посте
        public static async Task<Response<WallResponseFinal>> FetchWallInfo(string groupName) 
        {
            HttpResponseMessage response = await VKGet("wall.get", new Dictionary<string, string>
            {
                ["domain"] = groupName,
                ["offset"] = "1",
                ["fields"] = "",
                ["count"] = "30",
                ["lang"] = "rus",
            }); ;

            var content = await response.Content.ReadAsStringAsync();
            var posts = JsonSerializer.Deserialize<WallResponseFinal>(content);
            return new Response<WallResponseFinal>
            {
                response = posts,
                rawContent = content
            };
        }
    }
}
