using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using AppTicketCoral.Models;

namespace AppTicketCoral.Controllers
{
    public class UsuariosController : Controller
    {
        private TicketCoralEntities db = new TicketCoralEntities();
        HistoriesController carturer = new HistoriesController();


        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "UserID,Pass")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                Usuario user = db.Usuarios.Find(usuario.UserID);
                if (user.Pass == usuario.Pass)
                {
                    carturer.RegistrarEvento(usuario.NombreUsuario+" ha iniciado sesion"  );
                    return RedirectToAction("Index", "Coraltickets");
                }


            }

            return View(usuario);
        }



        public ActionResult Index()
        {
            return View(db.Usuarios.ToList());
        }

  
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

 
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,NombreUsuario,Pass,Operacion")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                carturer.RegistrarEvento("Se ha creado el registro de usuario: " + usuario.NombreUsuario);
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

 
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,NombreUsuario,Pass,Operacion")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                carturer.RegistrarEvento("Se ha editado el registro de usuario: " + usuario.NombreUsuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

 
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

     
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
            db.SaveChanges();
            carturer.RegistrarEvento("Se ha eliminado el registro de usuario: " + usuario.NombreUsuario);
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
