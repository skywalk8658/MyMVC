using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

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

        public virtual int ArtistId { get; set; }

        [Required(ErrorMessage ="Artist名稱欄位必填")]
        [StringLength(15)]
        [DataType(DataType.MultilineText)]
        public virtual string Name { get; set; }
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