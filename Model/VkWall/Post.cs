using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFVkontakte.Model.VkWall
{
    public class Item // данные о посте(пост может быть любой, будь то видео или только текст, но в основном пост с картинкой)
    {
        public string? inner_type { get; set; }
        public Donut? donut { get; set; }
        public Comments? comments { get; set; }
        public int marked_as_ads { get; set; }
        public float short_text_rate { get; set; }
        public string? hash { get; set; }
        public string? type { get; set; }
        public Attachment[]? attachments { get; set; }
        public int? date { get; set; }
        public int? from_id { get; set; }
        public int id { get; set; }
        public Likes? likes { get; set; }
        public int owner_id { get; set; }
        public Post_Source? post_source { get; set; }
        public string? post_type { get; set; }
        public Reposts? reposts { get; set; }
        public string? text { get; set; }
        public Views? views { get; set; }
        public string? Image1 { get; set; }
        public Copy_History[]? copy_history { get; set; }
        public string? GroupScreen_name { get; set; }
        public string? GroupPhoto_50 { get; set; }
        public bool zoom_text { get; set; }
    }

    public class Donut
    {
        public bool? is_donut { get; set; }
    } // данные о подписке Donut

    public class Comments
    {
        public int? can_post { get; set; }
        public int? can_view { get; set; }
        public int? count { get; set; }
    } // данные о комментариях

    public class Likes
    {
        public int? can_like { get; set; }
        public int? count { get; set; }
        public int? user_likes { get; set; }
        public int? can_publish { get; set; }
        public bool? repost_disabled { get; set; }
    } // данные о лайках и их кол-во

    public class Post_Source
    {
        public string? type { get; set; }
    } // тип поста

    public class Reposts
    {
        public int? count { get; set; }
        public int? user_reposted { get; set; }
    } // данные о репостах

    public class Views
    {
        public int? count { get; set; }
    } // количество просмотров

    public class Attachment
    {
        public string? type { get; set; }
        public Photo? photo { get; set; }
    } // вложения поста в случае фото

    public class Photo
    {
        public int? album_id { get; set; }
        public int? date { get; set; }
        public int? id { get; set; }
        public int? owner_id { get; set; }
        public string? access_key { get; set; }
        public int? post_id { get; set; }
        public Sizes[]? sizes { get; set; }
        public string? text { get; set; }
        public int? user_id { get; set; }
        public string? web_view_token { get; set; }
        public bool? has_tags { get; set; }
    } // данные о фото

    public class Sizes
    {
        public int height { get; set; }
        public string? type { get; set; }
        public int? width { get; set; }
        public string? url { get; set; }
    } // другие данные о фото(ссылка и размеры)

    public class Copy_History
    {
        public string? innerType { get; set; }
        public string? type { get; set; }
        public Attachment1[]? attachments { get; set; }
        public int? date { get; set; }
        public int? from_id { get; set; }
        public int? id { get; set; }
        public int? owner_id { get; set; }
        public Post_Source1? post_source { get; set; }
        public string? post_type { get; set; }
        public string? text { get; set; }
    } 
    public class Post_Source1
    {
        public string? platform { get; set; }
        public string? type { get; set; }
    } 
    public class Attachment1
    {
        public string? type { get; set; }
        public Video? video { get; set; }

    } 
    public class Video
    {
        public string? response_type { get; set; }
        public string? access_key { get; set; }
        public int? can_like { get; set; }
        public int? can_repost { get; set; }
        public int? can_add_to_faves { get; set; }
        public int? can_add { get; set; }
        public int? date { get; set; }
        public string? description { get; set; }
        public int? duration { get; set; }
        public Image[]? image { get; set; }
        public int? id { get; set; }
        public int? owner_id { get; set; }
        public string? title { get; set; }
        public string? track_code { get; set; }
        public string? type { get; set; }
        public int? views { get; set; }
        public string? platform { get; set; }
        public int? can_dislike
        {
            get; set;
        }
    } 
}
