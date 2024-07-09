using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvcentity;

namespace mvcentity.Controllers
{
    public class User_RegController : Controller
    {
        private MVCnewDBEntities db = new MVCnewDBEntities();

        // GET: User_Reg
        public ActionResult Index()
        {
            return View(db.User_Reg.ToList());
        }

        // GET: User_Reg/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Reg user_Reg = db.User_Reg.Find(id);
            if (user_Reg == null)
            {
                return HttpNotFound();
            }
            return View(user_Reg);
        }

        // GET: User_Reg/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User_Reg/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Age,Address,Email,Phone")] User_Reg user_Reg)
        {
            if (ModelState.IsValid)
            {
                db.User_Reg.Add(user_Reg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user_Reg);
        }

        // GET: User_Reg/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Reg user_Reg = db.User_Reg.Find(id);
            if (user_Reg == null)
            {
                return HttpNotFound();
            }
            return View(user_Reg);
        }

        // POST: User_Reg/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Age,Address,Email,Phone")] User_Reg user_Reg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_Reg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_Reg);
        }

        // GET: User_Reg/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Reg user_Reg = db.User_Reg.Find(id);
            if (user_Reg == null)
            {
                return HttpNotFound();
            }
            return View(user_Reg);
        }

        // POST: User_Reg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User_Reg user_Reg = db.User_Reg.Find(id);
            db.User_Reg.Remove(user_Reg);
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
