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


        public string Encriptar(string mensaje)
        {
            string result = string.Empty;
            byte[] encrypted = System.Text.Encoding.Unicode.GetBytes(mensaje);
            result = Convert.ToBase64String(encrypted);
            return result;
        }


        public string Desencriptar(string mensajeENC)
        {
            string result = string.Empty;
            byte[] decrypted = Convert.FromBase64String(mensajeENC);
            result = System.Text.Encoding.Unicode.GetString(decrypted);
            return result;
        }


        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "NombreUsuario,Pass,Operacion")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                foreach (var use in db.Usuarios.ToList())
                {
                    if (use.NombreUsuario==usuario.NombreUsuario)
                    {
                        if (usuario.Operacion== use.Operacion)
                        {
                            if (Desencriptar(use.Pass) == usuario.Pass)
                            {
                                carturer.RegistrarEvento(usuario.NombreUsuario + " ha iniciado sesion");

                                if (usuario.Operacion== "Soporte")
                                {
                                    return RedirectToAction("Index", "Coraltickets");
                                }
                                if (usuario.Operacion == "Empleado")
                                {
                                    return RedirectToAction("Index", "Coraltickets");
                                }
                                if (usuario.Operacion == "Cajero")
                                {
                                    return RedirectToAction("Index", "Coraltickets");
                                }
                                
                            }
                        }
                    }
                }
                return RedirectToAction("Login", "Usuarios");
            }

            return View(usuario);
        }



        public ActionResult Index()
        {
                List<Usuario> userList = new List<Usuario>();
            foreach (var user in db.Usuarios.ToList())
            {
                user.Pass= Desencriptar(user.Pass);
                userList.Add(user);

            }
            return View(userList);
        }

  
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            usuario.Pass = Desencriptar(usuario.Pass);
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

                usuario.Pass=Encriptar(usuario.Pass);
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
            usuario.Pass = Desencriptar(usuario.Pass);
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
                usuario.Pass = Encriptar(usuario.Pass);
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
