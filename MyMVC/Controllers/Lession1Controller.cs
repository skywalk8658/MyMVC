using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVC.Controllers
{
    public class Lession1Controller : Controller
    {
        // GET: Lession1
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index1A()
        {
            return View("IndexHello");
            //在View()裡面強制寫上檢視畫面的檔名
        }

        public ActionResult Index1B()
        {
            return View("~/Views/Lession1/IndexHello.cshtml");
            //在View()裡面強制寫上檢視畫面的完整路徑與檔名
        }

        public String Index1C()
        {
            return "這是Inex1C  <H3>回傳一個字串</H3>";
            //回傳一個字串
        }

        public ActionResult Index1D()
        {
            //回傳一個字串,使用text/palin，不會解讀HTML Tag
            //return Content("這是Inex1D  <H3>使用Content回傳一個Content字串</H3>", "text/palin", System.Text.Encoding.UTF8);
            //回傳一個字串,使用text/html，會解讀HTML Tag
            return Content("這是Inex1D  <H3>使用Content回傳一個Content字串</H3>", "text/html", System.Text.Encoding.UTF8);

        }

        public ActionResult Index1E()
        {
            return Redirect("https://www.hohoho.com.tw");
            //回傳轉址
        }

        //protected override void HandleUnknownAction(string actionName)
        //{
        //    Response.Redirect("https://www.pchome.com.tw/");
        //    //base.HandleUnknownAction(actionName);
        //    //找不到Action時，會進入此方法
        //}

        public ActionResult Index3()
        {
            //ViewData、ViewBag及TempData都是存在Session,變數名稱不能相同
            //ViewBag是ViewData的動態封裝器，兩者儲存內容是共用
            //ViewData["A"] = ViewBag.A
            ViewData["A"] = "(1).字串A 我是ViewData[]";
            ViewBag.B = "(2).字串B ViewBag";
            TempData["C"] = "(3).字串C TempData[]";
            ViewBag.Name = "Peter Bryan";
            return View();
        }

        public ActionResult Index4()
        {
            //強類型View part1
            //ViewBag指定型別
            var albums = new List<Models.Album>();
            for (int i = 0; i < 10; i++)
            {
                albums.Add(new Models.Album { Title = "Product " + i });
            }
            ViewBag.Albums = albums;
            return View();
        }
        public ActionResult Index5()
        {
            //強類型View part2
            //使用ViewData的Model屬性，可以用來在View中取得指定的模型對象
            //ViewData中只能包含一個模型對象 --> return View(albums);
            var albums = new List<Models.Album>();
            for (int i = 0; i < 10; i++)
            {
                albums.Add(new Models.Album { Title = "Album " + i });
            }

            //使用ViewBag再傳遞另一個模型
            var artists = new List<Models.Artist>();
            for (int i = 0; i < 10; i++)
            {
                artists.Add(new Models.Artist { Name = "John'number " + i });
            }
            ViewBag.Artists = artists;

            return View(albums);
        }

        public ActionResult Index6()
        {
            //Razor語法
            return View();
        }

        public ActionResult Index7()
        {
            //布局 SiteLayout.cshtml
            return View();
        }

        public ActionResult Index71()
        {
            //布局SiteLayout.cshtml View沒有footer的情況
            return View();
        }

        public ActionResult Index72()
        {
            //布局 SiteLayout.cshtml 使用Partial View 
            ViewBag.Message = "這是載入index72 部份視圖的Message文字內容!!!";
            return View();
        }
    }
}