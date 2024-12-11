using PROJETAKIP.Models.Personel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;

namespace PROJETAKIP.Models.ProjeTakip
{
    public class PersonelProjeleri
    {
        public PersonelProjeleri()
        {
            this.PersonelBilgileris=new HashSet<PersonelBilgileri>();
        }
        [Key]
        public int PersonelProjeID { get; set; }
        [DisplayName("PROJE BAŞLIĞI")]
        [StringLength(150, ErrorMessage = "Maksimum uzunluk 150 karakter olabilir")]
        public string ProjeBaslik { get; set; }

        public string ProjeAciklama { get; set; }

        public DateTime OlusturmaTarihi { get; set; }
        [DisplayName("ÖNCELİK DURUMU")]
        [StringLength(25, ErrorMessage = "Maksimum uzunluk 25 karakter olabilir")]

        public string OncelikDurumu { get; set; }

        public int TamamlanmaOrani { get; set; }

        public DateTime TamamlanmaTarihi { get; set; }

        public bool TamamlanmaDurumu { get; set; }
        public virtual ICollection<PersonelBilgileri> PersonelBilgileris { get; set; }
    }
}