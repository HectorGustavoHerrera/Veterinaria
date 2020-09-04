using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Veterinaria.AccesoDeDatos;
using Veterinaria.Models;
//(1)Creamos un Controlador//
//(6)Accion del controlador para reconocer la vista//
//(7) Ir a Layout y copiar ultima linea <li> y modificar datos para insert//
//(8) Copiar el metodo ActionResult y preguntamoa si es valido el objeto//
//(11) insertar el objeto dentro de la base de datos abajo de modelstate//
//(12) insertar una lista copiando el metodo insert y modificandolo//
//(14) Copiamos metodo actionresul y modificamos para la lista//
//(15) Ir a Layout y copiar ultima linea <li> y modificar datos de la lista//
//(16) redireccionar los datos a la lista//
//(19) creamos el metodo de actionresult y hacemos el update en accesodatos//
namespace Veterinaria.Controllers
{
    public class MascotaController : Controller
    {
        // GET: Mascota
        public ActionResult DatosMascota(int idMascota)
        {
            Mascota resultado = AD_Mascota.ObtenerMascota(idMascota);
            return View(resultado);
        }
        [HttpPost]
        public ActionResult DatosMascota(Mascota model)
        {
            if(ModelState.IsValid)
            {
                bool resultado = AD_Mascota.ActualizarDatosMascota(model);
                if(resultado)
                {
                    return RedirectToAction("ListadoMascotas", "Mascota");
                }
                else
                {
                    return View(model);
                }
            }
            return View();
        }

        public ActionResult AgregarMascota()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarMascota(Mascota model)
        {
            if(ModelState.IsValid)
            {
                bool resultado = AD_Mascota.InsertarNuevaMascota(model);
                if(resultado)
                {
                    return RedirectToAction("ListadoMascotas", "Mascota");
                }
                else
                {
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
            
        }

        public ActionResult ListadoMascotas()
        {
            List<Mascota> lista = AD_Mascota.ObtenerListasMascotas();
            return View(lista);
        }
    }
}