using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Response_Test.Data;
using Response_Test.Models;

namespace Response_Test.Controllers
{
    public class TesterInfomationModelsController : Controller
    {
        private Response_TestContext db = new Response_TestContext();

        // GET: TesterInfomationModels
        public ActionResult Index()
        {
            return View(db.TesterInfomationModels.ToList());
        }

        // GET: TesterInfomationModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TesterInfomationModel testerInfomationModel = db.TesterInfomationModels.Find(id);
            if (testerInfomationModel == null)
            {
                return HttpNotFound();
            }
            return View(testerInfomationModel);
        }

        // GET: TesterInfomationModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TesterInfomationModels/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TesterName")] TesterInfomationModel testerInfomationModel)
        {
            if (ModelState.IsValid)
            {
                db.TesterInfomationModels.Add(testerInfomationModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testerInfomationModel);
        }

        // GET: TesterInfomationModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TesterInfomationModel testerInfomationModel = db.TesterInfomationModels.Find(id);
            if (testerInfomationModel == null)
            {
                return HttpNotFound();
            }
            return View(testerInfomationModel);
        }

        // POST: TesterInfomationModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TesterInfomationModel testerInfomationModel = db.TesterInfomationModels.Find(id);
            db.TesterInfomationModels.Remove(testerInfomationModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
