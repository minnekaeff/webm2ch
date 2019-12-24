using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class HomeController : Controller
    {
        private static readonly HttpClient client = new HttpClient();
        //string uri = "https://2ch.hk/tv/res/2199315.json";
        //string _boardUri = "https://2ch.hk/b/catalog.json";
        string siteUri = "https://2ch.hk";

        public IActionResult Index()
        {
            return View();
        }

        List<string> Videos = new List<string>();

        List<Thread> _threadList = new List<Thread>();

        public async Task<IActionResult> About(string num)
        {
            var board = "b";
            string uri1 = "https://2ch.hk/" + board + "/res/" + num + ".json";
          
            RootObject root = new RootObject();
            HttpResponseMessage response = await client.GetAsync(uri1);
            if (response.IsSuccessStatusCode)
            {
                root = await response.Content.ReadAsAsync<RootObject>();
            }

            //поиск видео в потоке 
            foreach (var thread in root.threads)
            {
                foreach (var post in thread.posts)
                {
                    foreach(var file in post.files)
                    {
                        if (file.type == 10 /*mp4*/ || file.type == 6 /*webm*/)
                        {
                            string videoUri = string.Concat(siteUri, file.path);
                            //Добавить ссылку на видео в список
                            Videos.Add(videoUri);
                        }
                    }
                }
            }

            //стрингом отправить результат клиенту
            string dataStr = JsonConvert.SerializeObject(Videos, Formatting.None);
            ViewBag.Data = Videos;
            return View();
        }

        public async Task<IActionResult> Boards()
        {
            return View();
        }


        //выбор треда
        public async Task<IActionResult> Threads(string board, string type = "webm")
        {
            string uri = "https://2ch.hk/" + board + "/catalog.json";
            RootObject root = new RootObject();
            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                root = await response.Content.ReadAsAsync<RootObject>();
            }

            foreach (var thread in root.threads)
            {
                //ищет все треды с заголовком или с комментом "webm"
                if (thread.subject.ToLower().Contains(type) || 
                    thread.comment.ToLower().Contains(type))
                {
                    _threadList.Add( new Thread()
                    {
                        subject = thread.subject,
                        num = thread.num,
                        comment = Regex.Replace(thread.comment, "<[^>]+>", string.Empty)
                });
                }
            }

            return View(_threadList);
        }
    }
}
