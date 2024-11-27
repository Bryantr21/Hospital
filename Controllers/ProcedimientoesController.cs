using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hospital.Models;
using static Hospital.Models.Enum;

namespace Hospital.Controllers
{
    public class ProcedimientoesController : Controller
    {
        private HospitalesEntities db = new HospitalesEntities();

        // GET: Procedimientoes
        public ActionResult Index()
        {
            return View(db.Procedimientos.ToList());
        }

        // GET: Procedimientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procedimiento procedimiento = db.Procedimientos.Find(id);
            if (procedimiento == null)
            {
                return HttpNotFound();
            }
            return View(procedimiento);
        }

        // GET: Procedimientoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Procedimientoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_procedimiento,nombre,descripcion,costo")] Procedimiento procedimiento)
        {
            if (ModelState.IsValid)
            {
                db.Procedimientos.Add(procedimiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(procedimiento);
        }

        // GET: Procedimientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procedimiento procedimiento = db.Procedimientos.Find(id);
            if (procedimiento == null)
            {
                return HttpNotFound();
            }
            return View(procedimiento);
        }

        // POST: Procedimientoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_procedimiento,nombre,descripcion,costo")] Procedimiento procedimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(procedimiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(procedimiento);
        }

        // GET: Procedimientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procedimiento procedimiento = db.Procedimientos.Find(id);
            if (procedimiento == null)
            {
                return HttpNotFound();
            }
            return View(procedimiento);
        }

        // POST: Procedimientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Procedimiento procedimiento = db.Procedimientos.Find(id);
            db.Procedimientos.Remove(procedimiento);
            db.SaveChanges();
            SweetAlert("Eliminado", "procedimiento eliminado", NotificationType.success);

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
        #region Sweet Alert

        private void SweetAlert(string title, string msg, NotificationType type)
        {
            var script = "<script languaje='javascript'> " +
                         "Swal.fire({" +
                         "title: '" + title + "'," +
                         "text: '" + msg + "'," +
                         "icon: '" + type + "'" +
                         "});" +
                         "</script>";

            //TempData funciona como un viewBag, pasando información del controlador a cualquier parte de mi proyecto, siendo este más observable y con un tiempo de vida similar
            TempData["sweetalert"] = script;
        }

        private void SweetAlert_Eliminar(int id)
        {
            var script = "<script languaje='javascript'>" +
                "Swal.fire({" +
                "title: '¿Estás Seguro?'," +
                "text: 'Estás apunto de Eliminar el Camión: " + id.ToString() + "'," +
                "icon: 'info'," +
                "showDenyButton: true," +
                "showCancelButton: true," +
                "confirmButtonText: 'Eliminar'," +
                "denyButtonText: 'Cancelar'" +
                "}).then((result) => {" +
                "if (result.isConfirmed) {  " +
                "window.location.href = '/Camiones/Eliminar_Camion/" + id + "';" +
                "} else if (result.isDenied) {  " +
                "Swal.fire('Se ha cancelado la operación','','info');" +
                "}" +
                "});" +
                "</script>";

            TempData["sweetalert"] = script;
        }
        #endregion
    }
}
