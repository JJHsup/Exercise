using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web_Crawler_API.Data;
using Web_Crawler_API.Models;

namespace Web_Crawler_API.Controllers
{
    public class PlayersModelsController : Controller
    {
        private Web_Crawler_APIContext db = new Web_Crawler_APIContext();

        // GET: PlayersModels
        public ActionResult Index()
        {
            return View(db.APlayer.ToList());
        }

        // GET: PlayersModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayersModel playersModel = db.APlayer.Find(id);
            if (playersModel == null)
            {
                return HttpNotFound();
            }
            return View(playersModel);
        }

        // GET: PlayersModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlayersModels/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PlayerName,G,PTS,TRB,AST,FG,FG3,FT,eFG,PER,WS")] PlayersModel playersModel)
        {
            if (ModelState.IsValid)
            {
                db.APlayer.Add(playersModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(playersModel);
        }

        // GET: PlayersModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayersModel playersModel = db.APlayer.Find(id);
            if (playersModel == null)
            {
                return HttpNotFound();
            }
            return View(playersModel);
        }

        // POST: PlayersModels/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PlayerName,G,PTS,TRB,AST,FG,FG3,FT,eFG,PER,WS")] PlayersModel playersModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playersModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(playersModel);
        }

        // GET: PlayersModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayersModel playersModel = db.APlayer.Find(id);
            if (playersModel == null)
            {
                return HttpNotFound();
            }
            return View(playersModel);
        }

        // POST: PlayersModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayersModel playersModel = db.APlayer.Find(id);
            db.APlayer.Remove(playersModel);
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
