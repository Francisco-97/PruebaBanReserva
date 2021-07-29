using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prueba_BanReservas.Models;

namespace Prueba_BanReservas.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        [HttpGet]
        public ActionResult Agregar()
        {
            return View();
        }
        //Este es el metodo Post que nos sirve para Registrar persona y redireccionarla a la vista del Listado
        [HttpPost]
        public ActionResult Agregar(Persona persona)
        {
            bool state = persona.guardar();

            if (state)
            {

                return RedirectToAction("ListadoPersona", "Persona");
            }
            else
            {

                return View(persona);

            }

        }

        
        [HttpGet]
        public ActionResult ListadoPersona()
        {
            //Este metodo nos muestra el listado de las personas registradas

            List<Persona> listadoPersona = new List<Persona>();
            try
            {
                using (var con = new PruebaBrCon())
                {
                    listadoPersona = con.Persona.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return View(listadoPersona);
        }

        public ActionResult EliminarPersona(int id)
        {

            //Este metodo nos ayuda a Eliminar los registros de una Persona ya registrada
            try
            {
                using (var con = new PruebaBrCon())
                {
                    Persona persona;
                    persona = con.Persona.Where(x => x.Id == id).SingleOrDefault();
                    con.Entry(persona).State = System.Data.Entity.EntityState.Deleted;
                    con.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return RedirectToAction("ListadoPersona");
        }

    }
}