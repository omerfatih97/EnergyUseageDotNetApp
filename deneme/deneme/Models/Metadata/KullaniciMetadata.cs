using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace deneme.Models
{
    public partial class Kullanici
    {

        [Required(ErrorMessage = "Bu Alanın Doldurulması Zorunludur.", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [DisplayName("Şifre Doğrulama:")]
        public string sifredogrula { get; set; }

        [DisplayName("Kullanım Koşullarını Kabul Ediyorum.")]
        public bool agree { get; set; }


        [DisplayName("Resim:")]
        public byte[] resim { get; set; }


    }
    public partial class resimler
    {
        [DisplayName("Resim:")]
        public byte[] resim { get; set; }
        public int user_id { get; set; }
    }
}