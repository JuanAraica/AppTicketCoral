using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppTicketCoral.Models;

namespace AppTicketCoral.Controllers
{
    public class ProductosBayersController : Controller
    {
        private TicketCoralEntities db = new TicketCoralEntities();

        // GET: ProductosBayers
        public ActionResult Index()
        {
            return View(db.ProductosBayers.ToList());
        }

        // GET: ProductosBayers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductosBayer productosBayer = db.ProductosBayers.Find(id);
            if (productosBayer == null)
            {
                return HttpNotFound();
            }
            return View(productosBayer);
        }

        // GET: ProductosBayers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductosBayers/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Descripcion,Costo,Proveedor,CCompra,Iva,SubPro,Empresa,codigo_cabys")] ProductosBayer productosBayer)
        {
            if (ModelState.IsValid)
            {
                db.ProductosBayers.Add(productosBayer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productosBayer);
        }

        // GET: ProductosBayers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductosBayer productosBayer = db.ProductosBayers.Find(id);
            if (productosBayer == null)
            {
                return HttpNotFound();
            }
            return View(productosBayer);
        }

        // POST: ProductosBayers/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Descripcion,Costo,Proveedor,CCompra,Iva,SubPro,Empresa,codigo_cabys")] ProductosBayer productosBayer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productosBayer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productosBayer);
        }

        // GET: ProductosBayers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductosBayer productosBayer = db.ProductosBayers.Find(id);
            if (productosBayer == null)
            {
                return HttpNotFound();
            }
            return View(productosBayer);
        }

        // POST: ProductosBayers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductosBayer productosBayer = db.ProductosBayers.Find(id);
            db.ProductosBayers.Remove(productosBayer);
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
