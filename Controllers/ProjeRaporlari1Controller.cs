using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PROJETAKIP.Models.DataContext;
using PROJETAKIP.Models.Personel;

namespace PROJETAKIP.Controllers
{
    public class ProjeRaporlari1Controller : Controller
    {
        private ProjeTakipDBContext db = new ProjeTakipDBContext();
        // GET: ProjeRaporlari1
        public ActionResult CanliDestek()
        {
            var destek = db.PersonelBilgileris.Where(x => x.Departman == "Yönetim");
            return View(destek.ToList());
        }
    }
}