using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaTecnicaCDGA.Models;
using PruebaTecnicaCDGA.Models.ViewModels;

namespace PruebaTecnicaCDGA.Controllers
{
    public class dbEmpleadoController : Controller
    {
        // GET: dbEmpleado
        public ActionResult Index()
        {
            List<ListdbEmpleadoVM> lst;
            using (dbEmpleadoEntities db = new dbEmpleadoEntities())
            {
                lst = (from d in db.Empleados
                       select new ListdbEmpleadoVM
                       {
                           idEmpleado = d.idEmpleado,
                           Nombre = d.Nombre,
                           Apellido = d.Apellido,
                           Direccion = d.Direccion,
                           Telefono = d.Telefono,
                           idPuesto = (int)d.idPuesto,
                           DPI = d.DPI,
                           FechaNacimiento = (DateTime)d.FechaNacimiento,
                           FechaIngresoRegistro = (DateTime)d.FechaIngresoRegistro
                       }).ToList();
            }

            return View(lst);
        }

        public ActionResult NuevoEmpleado()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevoEmpleado(dbEmpleadoVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dbEmpleadoEntities db = new dbEmpleadoEntities())
                    {
                        var table = new Empleados();
                        table.idEmpleado = model.idEmpleado;
                        table.Nombre = model.Nombre;
                        table.Apellido = model.Apellido;
                        table.Direccion=model.Direccion;
                        table.Telefono =model.Telefono;
                        table.idPuesto = model.idPuesto;
                        table.DPI = model.DPI;
                        table.FechaNacimiento = model.FechaNacimiento;
                        table.FechaIngresoRegistro = model.FechaIngresoRegistro;

                        db.Empleados.Add(table);
                        db.SaveChanges();
                    }
                    return Redirect("~/dbEmpleado");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult EditarEmpleado(int id)
        {
            dbEmpleadoVM model = new dbEmpleadoVM();
            using (dbEmpleadoEntities db = new dbEmpleadoEntities())
            {
                var e = db.Empleados.Find(id);
                model.Nombre = e.Nombre;
                model.Apellido = e.Apellido;
                model.Direccion = e.Direccion;
                model.Telefono = e.Telefono;
                model.idPuesto = (int)e.idPuesto;
                model.DPI = e.DPI;
                model.FechaNacimiento = (DateTime)e.FechaNacimiento;
                model.FechaIngresoRegistro = (DateTime)e.FechaIngresoRegistro;
                model.idEmpleado = (int)e.idEmpleado;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarEmpleado(dbEmpleadoVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dbEmpleadoEntities db = new dbEmpleadoEntities())
                    {
                        var table = db.Empleados.Find(model.idEmpleado);
                        table.idEmpleado = model.idEmpleado;
                        table.Nombre = model.Nombre;
                        table.Apellido = model.Apellido;
                        table.Direccion = model.Direccion;
                        table.Telefono = model.Telefono;
                        table.idPuesto = model.idPuesto;
                        table.DPI = model.DPI;
                        table.FechaNacimiento = model.FechaNacimiento;
                        table.FechaIngresoRegistro = model.FechaIngresoRegistro;

                        db.Entry(table).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/dbEmpleado");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult EliminarEmpleado(int id)
        {
            dbEmpleadoVM model = new dbEmpleadoVM();
            using (dbEmpleadoEntities db = new dbEmpleadoEntities())
            {
                var e = db.Empleados.Find(id);
                db.Empleados.Remove(e);
                db.SaveChanges();
            }
            return Redirect("~/dbEmpleado");
        }
    }
}