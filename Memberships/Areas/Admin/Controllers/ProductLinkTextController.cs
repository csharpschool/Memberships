using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Memberships.Entities;
using Memberships.Models;

namespace Memberships.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductLinkTextController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ProductLinkText
        public async Task<ActionResult> Index()
        {
            return View(await db.ProductLinkTexts.ToListAsync());
        }

        // GET: Admin/ProductLinkText/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductLinkText productLinkText = await db.ProductLinkTexts.FindAsync(id);
            if (productLinkText == null)
            {
                return HttpNotFound();
            }
            return View(productLinkText);
        }

        // GET: Admin/ProductLinkText/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductLinkText/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title")] ProductLinkText productLinkText)
        {
            if (ModelState.IsValid)
            {
                db.ProductLinkTexts.Add(productLinkText);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(productLinkText);
        }

        // GET: Admin/ProductLinkText/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductLinkText productLinkText = await db.ProductLinkTexts.FindAsync(id);
            if (productLinkText == null)
            {
                return HttpNotFound();
            }
            return View(productLinkText);
        }

        // POST: Admin/ProductLinkText/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title")] ProductLinkText productLinkText)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productLinkText).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(productLinkText);
        }

        // GET: Admin/ProductLinkText/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductLinkText productLinkText = await db.ProductLinkTexts.FindAsync(id);
            if (productLinkText == null)
            {
                return HttpNotFound();
            }
            return View(productLinkText);
        }

        // POST: Admin/ProductLinkText/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ProductLinkText productLinkText = await db.ProductLinkTexts.FindAsync(id);
            var isUnused = await db.Products.CountAsync(i => i.ProductLinkTextId.Equals(id)) == 0;
            if (isUnused)
            {
                db.ProductLinkTexts.Remove(productLinkText);
                await db.SaveChangesAsync();
            }

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
