using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication7
{
    public class NewsAbu
    {
        public string date { get; set; }
        public int num { get; set; }
        public string subject { get; set; }
        public int views { get; set; }
    }

    public class Files
    {
        public string path { get; set; }
        public int type { get; set; }
    }

    public class Post
    {
        public int banned { get; set; }
        public int closed { get; set; }
        public string comment { get; set; }
        public string date { get; set; }
        public string email { get; set; }
        public int endless { get; set; }
        public List<Files> files { get; set; }
        public int lasthit { get; set; }
        public string name { get; set; }
        public int num { get; set; }
        public int number { get; set; }
        public int op { get; set; }
        public string parent { get; set; }
        public int sticky { get; set; }
        public string subject { get; set; }
        public string tags { get; set; }
        public int timestamp { get; set; }
        public string trip { get; set; }
    }

    public class Thread
    {
        public List<Post> posts { get; set; }
        public string subject { get; set; }
        public string comment { get; set; }
        public string num { get; set; }
    }

    public class Top
    {
        public string board { get; set; }
        public string info { get; set; }
        public string name { get; set; }
    }

    public class RootObject
    {
        public string Board { get; set; }
        public string BoardInfo { get; set; }
        public string BoardInfoOuter { get; set; }
        public string BoardName { get; set; }
        public string advert_bottom_image { get; set; }
        public string advert_bottom_link { get; set; }
        public string advert_mobile_image { get; set; }
        public string advert_mobile_link { get; set; }
        public string advert_top_image { get; set; }
        public string advert_top_link { get; set; }
        public string board_banner_image { get; set; }
        public string board_banner_link { get; set; }
        public int bump_limit { get; set; }
        public string current_thread { get; set; }
        public string default_name { get; set; }
        public int enable_dices { get; set; }
        public int enable_flags { get; set; }
        public int enable_icons { get; set; }
        public int enable_images { get; set; }
        public int enable_likes { get; set; }
        public int enable_names { get; set; }
        public int enable_oekaki { get; set; }
        public int enable_posting { get; set; }
        public int enable_sage { get; set; }
        public int enable_shield { get; set; }
        public int enable_subject { get; set; }
        public int enable_thread_tags { get; set; }
        public int enable_trips { get; set; }
        public int enable_video { get; set; }
        public int files_count { get; set; }
        public int is_board { get; set; }
        public int is_closed { get; set; }
        public int is_index { get; set; }
        public int max_comment { get; set; }
        public int max_files_size { get; set; }
        public int max_num { get; set; }
        public List<NewsAbu> news_abu { get; set; }
        public int posts_count { get; set; }
        public List<Thread> threads { get; set; }
        public string title { get; set; }
        public List<Top> top { get; set; }
        public string unique_posters { get; set; }
    }
}
