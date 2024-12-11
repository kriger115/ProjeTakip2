using PROJETAKIP.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace PROJETAKIP.Controllers
{
    public class GenelBakisController : Controller
    {
        private ProjeTakipDBContext db = new ProjeTakipDBContext();
        // GET: GenelBakis
        public ActionResult Index()
        {
            int projesayisi = db.PersonelProjeleris.Count();
            ViewBag.ProjeSayisi = projesayisi;


            int tamamlanmisProje = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == true).Count();
            ViewBag.TamamlanmisProje = tamamlanmisProje;

            var yuksekOncelikliProjeler = db.PersonelProjeleris.Where(p => p.OncelikDurumu == "Yüksek Öncelikli").Count();
            ViewBag.YuksekOncelikli = yuksekOncelikliProjeler;

            var ortaOncelikliProjeler = db.PersonelProjeleris.Where(p => p.OncelikDurumu == "Orta Öncelikli").Count();
            ViewBag.OrtaOncelikli = ortaOncelikliProjeler;

            var dusukOncelikliProjeler = db.PersonelProjeleris.Where(p => p.OncelikDurumu == "Düşük Öncelikli").Count();
            ViewBag.DusukOncelikli = dusukOncelikliProjeler;

            var basariliveyuksek = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == true && p.OncelikDurumu == "Yüksek Öncelikli").Count();
            ViewBag.YuksekVeBasarili = basariliveyuksek;

            var basariliveorta = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == true && p.OncelikDurumu == "Orta Öncelikli").Count();
            ViewBag.OrtaVeBasarili = basariliveorta;

            var basarilivedusuk = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == true && p.OncelikDurumu == "Düşük Öncelikli").Count();
            ViewBag.DusukVeBasarili = basarilivedusuk;


            int tamamlanmamisProje = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == false).Count();
            ViewBag.TamamlanmamisProje = tamamlanmamisProje;

            var personelProjeListesi = db.PersonelProjeleris.ToList();
            var personelTamamlanmisProjeSayisi = new Dictionary<int, int>(); //Personelid-Tamamlanmış proje sayısı çiftlerini tutmak için
            foreach (var personel in db.PersonelBilgileris.ToList())
            {
                int tamamlanmisProjeSayisi = 0;
                foreach (var proje in personel.PersonelProjeleris)
                {
                    if (proje.TamamlanmaDurumu == true)
                    {
                        tamamlanmisProjeSayisi++;
                    }
                }
                personelTamamlanmisProjeSayisi[personel.PersonelBilgileriID]= tamamlanmisProjeSayisi;
            }
            
            var siraliPersonelListesi=personelTamamlanmisProjeSayisi.OrderByDescending(x=>x.Value); //tamamlanmış proje sayısınagöre personelleri sırala
            var enCokTamamlananPersonelID = siraliPersonelListesi.First().Key; //en çok tamamlanma sayısına sahip personeli al
            var enCokTamamlananPersonel=db.PersonelBilgileris.FirstOrDefault(p=>p.PersonelBilgileriID==enCokTamamlananPersonelID);
            ViewBag.EnCokTamamlayanPersonelBilgisi = enCokTamamlananPersonel.AdSoyad;


            int enCokProjeTamamlayanPersonelProjeSayisi = personelTamamlanmisProjeSayisi[enCokTamamlananPersonelID];
            ViewBag.EnCokProjeTamamlayanPersonelinProjeSayisi = enCokProjeTamamlayanPersonelProjeSayisi;
            return View();
        }

        public ActionResult Genelİstatistik()
        {
            var personeller=db.PersonelBilgileris.ToList();
            var personelProjeleri=db.PersonelProjeleris.ToList();
            var tamamlananProjeSayisi=new Dictionary<int, int>();
            var tamamlanmayanProjeSayisi=new Dictionary<int, int>();
            var toplamProjeSayisi= new Dictionary<int, int>();
            foreach(var personel in personeller)
            {
                int tamamlananProje = 0;
                int tamamlanmayanProje = 0;
                int toplamProje = 0;
                foreach(var proje in personelProjeleri)
                {
                    if (proje.PersonelBilgileris.Contains(personel))
                    {
                        toplamProje++;
                        if (proje.TamamlanmaDurumu)
                        {
                            tamamlananProje++;
                        }
                        else
                        {
                            tamamlanmayanProje++;
                        }
                    }
                }
                tamamlananProjeSayisi[personel.PersonelBilgileriID]=tamamlananProje;
                tamamlanmayanProjeSayisi[personel.PersonelBilgileriID]=tamamlanmayanProje;
                toplamProjeSayisi[personel.PersonelBilgileriID] = toplamProje;
            }


            ViewBag.TamamlananProjeSayisi=tamamlananProjeSayisi;
            ViewBag.TamamlanmayanProjeSayisi = tamamlanmayanProjeSayisi;
            ViewBag.ToplamProjeSayisi = toplamProjeSayisi;


            int projesayisi = db.PersonelProjeleris.Count();
            ViewBag.ProjeSayisi = projesayisi;

            int personelsayisi = db.PersonelBilgileris.Count();
            ViewBag.PersonelSayisi = personelsayisi;

            int tamamlanmisProje = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == true).Count();
            ViewBag.TamamlanmisProje = tamamlanmisProje;

            int tamamlanmamisProje = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == false).Count();
            ViewBag.TamamlanmamisProje = tamamlanmamisProje;

            var basarisizveyuksek = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == false && p.OncelikDurumu == "Yüksek Öncelikli").Count();
            ViewBag.YuksekVeBasarisiz = basarisizveyuksek;

            var basarisizveorta = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == false && p.OncelikDurumu == "Orta Öncelikli").Count();
            ViewBag.OrtaVeBasarisiz = basarisizveorta;

            return View(personeller);
        }
   
    }
}
