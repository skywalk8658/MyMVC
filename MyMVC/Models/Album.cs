using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyMVC.Models
{
    public class Album
    {
        public virtual int AlbumId { get; set; }
        public virtual int GenreId { get; set; }
        public virtual int ArtistId { get; set; }
        public virtual string Title { get; set; }
        public virtual decimal Price { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }

    }

    public class Artist
    {

        [Range(1,150)]//設定數值可輸入範圍，Range可用於數字型別
        // [Range(typeof(decimal),"0.00","49.99")] //格式化為decimal
        // 處理屬性格式化-ApplyFormatInEditMode=true將屬性格式化為表單輸入元素
        // [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString="{0:c}")] //處理屬性格式化
        // [ReadOnly(true)] //不讓模型綁定器的新值更新屬性
        public virtual int ArtistId { get; set; }

        //ErrorMessage 自定義錯誤訊息
        [Required(ErrorMessage ="Artist名稱欄位必填")]//必填
        //[Required(ErrorMessage = "{0} 名稱欄位必填")]//必填
        [StringLength(15,MinimumLength=5)]//最大長度15，最少5個字元
        [DataType(DataType.MultilineText)]//讓Html輔助器Editor自動生成特性為MultilineText
        [RegularExpression(@"[A-Za-z0-9._%+-]")]//使用正規表達示
        [System.Web.Mvc.Remote("CheckUserName","Account")]//remote可以調整Server端的函式執行驗證
        [Display(Name="藝術家名稱")] //使用Editor輔助顯示的名稱
        [ScaffoldColumn(false)] //讓EditorForModel及DisplayForModel不自動生成這個欄位
        public virtual string Name { get; set; }

        // [Compare("Email")]//和另外一欄位比較，像是要求輸入兩次email地址
        // public virtual string EmailConfirm { get; set; }        
    }



    public class Genre
    {
        public virtual int GenreId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Desc { get; set; }
        public virtual List<Album> Albums { get; set; }
    }

    public class BankCode
    {
        public virtual int BankId { get; set; }
        
        public virtual string BankName { get; set; }
        public virtual string BankNo { get; set; }

    }
}