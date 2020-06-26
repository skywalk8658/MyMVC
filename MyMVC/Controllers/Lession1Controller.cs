using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMVC.Models;

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
            ViewBag.Msg = "<script>alert('無編碼代碼表達式!');</script>";
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
            ViewBag.Message = "這是載入Index72 部份視圖的ViewBag.Message文字內容!!!";
            return View();
        }

        List<BankCode> listBank = new List<BankCode> {
                new BankCode() { BankId=1001, BankName="中國信托", BankNo="810" }
               ,new BankCode() { BankId=1002, BankName="台新銀行", BankNo="820" }
               ,new BankCode() { BankId=1003, BankName="花旗銀行", BankNo="830" }
            };

        public ActionResult IndexBank1()
        {
            List<BankCode> list = null;
            if (Session["Bank"] == null)
                Session["Bank"] = list = listBank;
            else
                list = Session["Bank"] as List<BankCode>;

            Session["Bank"] = list = list.Count == 0  ? listBank : list;//若是都沒資料，就重新給
            return View(list);
        }

        public ActionResult Delete(int id = 1003)
        {
            List<BankCode> list = null;
            if (Session["Bank"] == null)
                Session["Bank"] = listBank;
            else
                list = Session["Bank"] as List<BankCode>;

            var item = from b in list
                       where b.BankId.Equals(id)
                       select b;
            list.Remove(item.FirstOrDefault());
            Session["Bank"] = list;

            return RedirectToAction("IndexBank1");
            //return View("IndexBank1");
        }

        public ActionResult Index8()
        {
            ViewBag.Message = "Index8";
            return View();
        }

        public ActionResult Index81()
        {
            ViewBag.QMsg = Request["q"];
            return View();
        }

        public ActionResult Index9()
        {
            //Html.BeginForm
            //Html.ValidationSummary
            ModelState.AddModelError("", "這是模型級別的錯誤!");
            //增加一個Title屬性的錯誤
            ModelState.AddModelError("Title", "這是與Title屬性相關聯的錯誤!");
            //Html.TextBox("Price")自動繫結ViewBag.Price
            ViewBag.Price = 95.7;
            ViewBag.Album = new Album { Price = 23 };
            SelectListItem item = new SelectListItem() { Text= "Apple", Value="apple" };
            IList<SelectListItem> list = new List<SelectListItem>() {
                new SelectListItem() { Text= "Apple", Value="apple"}
               ,new SelectListItem() { Text= "Orange", Value="orange"}
             };
            
            ViewBag.Genres = new SelectList(list, "Value", "Text");

            var artist = new Artist { Name = "習大大的強型別", ArtistId=2134 };
            return View(artist);
        }

        [ChildActionOnly]
        public ActionResult Index91()
        {
            //設定ChildActionOnly屬性，避免通過URL來調用Index91操作，
            //限制只能通過Action或RenderAction方法來調用子操作，像是顯示網站菜單
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult Index92(BankCode banks)
        {
            //PartialView 接收一個物件
            return PartialView(banks);
        }    

        [ChildActionOnly]
        [AcionName("AddBank")]
        public ActionResult Index93()
        {
            //設定ChildActionOnly屬性，避免通過URL來調用Index91操作，
            //限制只能通過Action或RenderAction方法來調用子操作，像是顯示網站菜單
            return PartialView();
        }    
    
        public ActionResult Index10()
        {
            //驗證和模型狀態
            //模型狀態中存在錯誤，ModelState.IsValid會返回false，下面所有表達式都返回true
            //ModelState.IsValid == false
            //ModelState.IsValidField("Name") == false
            //ModelState["Name"].Errors.Count > 0 
            
            //在模型狀態中查看驗證失敗錯誤訊息
            //var ErrMsg= ModelState["Name"].Errors[0].ErrorMessage;

            if(ModelState.IsValid)
            {
                //驗證成功後要處理的內容
                string Msg="";

            }
            return PartialView();
        }        


    }
}