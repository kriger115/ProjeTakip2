using PROJETAKIP.Models.DataContext;
using PROJETAKIP.Models.ProjeTakip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PROJETAKIP.Controllers
{
    public class PersonelProjeController : Controller
    {
        private ProjeTakipDBContext db = new ProjeTakipDBContext();


        // GET: PersonelProje
        public ActionResult Index()
        {

            var projelistele = db.PersonelProjeleris.ToList();
            return View(projelistele);
        }

        public ActionResult Create()
        {
            ViewBag.PersonelBilgileriID = new SelectList(db.PersonelBilgileris, "PersonelBilgileriID", "AdSoyad");
            return View();
        }
        [HttpPost]
        public ActionResult Create(PersonelProjeleri projeObj, int[] PersonelBilgileriID)
        {

            foreach (var x in PersonelBilgileriID)
            {
                projeObj.PersonelBilgileris.Add(db.PersonelBilgileris.Find(x));
            }
            projeObj.OlusturmaTarihi = DateTime.Now;
            projeObj.TamamlanmaTarihi = DateTime.Now;
            db.PersonelProjeleris.Add(projeObj);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var projeObj = db.PersonelProjeleris.Find(id);
            return View(projeObj);
        }
        [HttpPost]
        public ActionResult Edit(PersonelProjeleri projeObj)
        {
            var projeDbOb = db.PersonelProjeleris.Find(projeObj.PersonelProjeID);
            projeDbOb.ProjeAciklama=projeObj.ProjeAciklama;
            projeDbOb.ProjeBaslik=projeObj.ProjeBaslik;
            projeDbOb.TamamlanmaOrani=projeObj.TamamlanmaOrani;
            projeDbOb.OncelikDurumu=projeObj.OncelikDurumu;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Tamamla(int id)
        {
            var projeObj = db.PersonelProjeleris.Find(id);
            projeObj.TamamlanmaDurumu=true;
            projeObj.TamamlanmaOrani = 100;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}