using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ecommerce.MVC.Models;

namespace ecommerce.MVC.Controllers
{
    public class ClienteController : Controller
    {
        private BDDCORDICARRITOEntities db = new BDDCORDICARRITOEntities();

        // GET: Cliente
        public async Task<ActionResult> Index()
        {
            return View(await db.TBL_CLIENTE.ToListAsync());
        }

        // GET: Cliente/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_CLIENTE tBL_CLIENTE = await db.TBL_CLIENTE.FindAsync(id);
            if (tBL_CLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(tBL_CLIENTE);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            List<SelectListItem> listaTipo = new List<SelectListItem>()
            {
                new SelectListItem {Text="Seleccione", Value="0", Selected=true },
                new SelectListItem {Text="Cedula", Value="CE", Selected=true },
                new SelectListItem {Text="Ruc", Value="RU", Selected=true },
                new SelectListItem {Text="Pasaporte", Value="PA", Selected=true },
            };

            ViewBag.objetoListaTipo = new SelectList(listaTipo, "Value", "Text");

            return View();
        }

        // POST: Cliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "cli_id,cli_identificacion,cli_tipoidentificacion,cli_apellidos,cli_nombres,cli_genero,cli_fechanacimiento,cli_telefono,cli_celurar,cli_email,cli_status,cli_fechacreacion")] TBL_CLIENTE tBL_CLIENTE)
        {
            if (ModelState.IsValid)
            {
                db.TBL_CLIENTE.Add(tBL_CLIENTE);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tBL_CLIENTE);
        }

        // GET: Cliente/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_CLIENTE tBL_CLIENTE = await db.TBL_CLIENTE.FindAsync(id);
            if (tBL_CLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(tBL_CLIENTE);
        }

        // POST: Cliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "cli_id,cli_identificacion,cli_tipoidentificacion,cli_apellidos,cli_nombres,cli_genero,cli_fechanacimiento,cli_telefono,cli_celurar,cli_email,cli_status,cli_fechacreacion")] TBL_CLIENTE tBL_CLIENTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_CLIENTE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tBL_CLIENTE);
        }

        // GET: Cliente/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_CLIENTE tBL_CLIENTE = await db.TBL_CLIENTE.FindAsync(id);
            if (tBL_CLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(tBL_CLIENTE);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            TBL_CLIENTE tBL_CLIENTE = await db.TBL_CLIENTE.FindAsync(id);
            db.TBL_CLIENTE.Remove(tBL_CLIENTE);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public ActionResult validarIdentificacion(string tipoIdentificacion, string identificacion)
        {
            bool status = false;
            if (!string.IsNullOrEmpty(tipoIdentificacion) && !string.IsNullOrEmpty(identificacion))
            {
                if (tipoIdentificacion.Equals("Cedula"))
                {
                    status = LogicWeb.Validaciones.VerificarCedula(identificacion);
                }
                else if (tipoIdentificacion.Equals("Ruc"))
                {
                    status = LogicWeb.Validaciones.VerificarRUC(identificacion);
                } 
            }
            return new JsonResult { Data = new { status = status } };
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
