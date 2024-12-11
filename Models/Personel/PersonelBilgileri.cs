using PROJETAKIP.Models.ProjeTakip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PROJETAKIP.Models.Personel
{

    public class PersonelBilgileri
    {
        public PersonelBilgileri()
        {
            this.PersonelProjeleris=new HashSet<PersonelProjeleri>();
        }
        [Key]
        public int PersonelBilgileriID { get; set; }

        [DisplayName("E-POSTA")]
        public string Eposta { get; set; }
        [DisplayName("ŞİFRE")]
        [StringLength(25, ErrorMessage = "Maksimum uzunluk 25 karakter olabilir")]
        public string Sifre { get; set; }
        [DisplayName("YETKİ")]
        [StringLength(15, ErrorMessage = "Maksimum uzunluk 15 karakter olabilir")]
        public string Yetki { get; set; }
        [DisplayName("AD SOYAD")]
        [StringLength(50, ErrorMessage = "Maksimum uzunluk 50 karakter olabilir")]
        public string AdSoyad { get; set; }


        [DisplayName("PERSONEL FOTOĞRAFI")]
        public string PersonelGöreseli { get; set; }


        [DisplayName("TC KİMLİK NO")]
        [StringLength(15, ErrorMessage = "Maksimum uzunluk 15 karakter olabilir")]
        public string TCNO { get; set; }
        [DisplayName("DEPARTMANI")]
        public string Departman { get; set; }
        [StringLength(25, ErrorMessage = "Maksimum uzunluk 25 karakter olabilir")]
        [DisplayName("GÖREVİ")]

        public string Gorev { get; set; }
        [DisplayName("AÇIKLAMA")]
        public string PozisyonAciklama { get; set; }
        [DisplayName("TELEFON NUMARASI")]
        [StringLength(15, ErrorMessage = "Maksimum uzunluk 15 karakter olabilir")]
        public string TelNo { get; set; }
        [DisplayName("ADRES")]
        public string Adres { get; set; }
        [DisplayName("MEDENİ HAL")]
        [StringLength(25, ErrorMessage = "Maksimum uzunluk 25 karakter olabilir")]
        public string MedeniHal { get; set; }
        [DisplayName("YAKIN BİLGİSİ")]
        [StringLength(25, ErrorMessage = "Maksimum uzunluk 25 karakter olabilir")]
        public string YakinBilgisi { get; set; }
        [DisplayName("YAKIN TC KİMLİK NO")]
        [StringLength(15, ErrorMessage = "Maksimum uzunluk 15 karakter olabilir")]
        public string YakinTC { get; set; }
        [DisplayName("YAKIN AD SOYAD")]
        [StringLength(25, ErrorMessage = "Maksimum uzunluk 25 karakter olabilir")]
        public string YakinAdSoyad { get; set; }
        [DisplayName("YAKIN TELEFONU")]
        [StringLength(15, ErrorMessage = "Maksimum uzunluk 15 karakter olabilir")]
        public string YakinTel { get; set; }
        [DisplayName("DOĞUM TARİHİ")]
        public DateTime DogumTarihi { get; set; }
        [DisplayName("İŞE GİRİŞ TARİHİ")]
        public DateTime? IseGirisTarihi { get; set; }
        public virtual ICollection<PersonelProjeleri> PersonelProjeleris { get; set; }

    }

}