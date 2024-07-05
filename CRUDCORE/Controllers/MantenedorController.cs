using Microsoft.AspNetCore.Mvc;
using CRUDCORE.Datos;
using CRUDCORE.Models;

namespace CRUDCORE.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos _ContactoDatos = new ContactoDatos(); 
        public IActionResult Listar()
        {
            //LA VISTA MOSTRAR UNA LISTA DE CONTACTOS
            var oLista = _ContactoDatos.Listar();
            return View(oLista);
        }
        public IActionResult Guardar()
        {
            //METODO SOLO DEVUELVE LA VISTA
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(ContactoModel oContacto)
        {
            //MEOTODO RECIBE EL OBJETO PARA GUARDARLO EN BD
            if (!ModelState.IsValid)
            {
                return View();
            }
            var rpsta = _ContactoDatos.Guardar(oContacto);
            if (rpsta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Editar(int IdContacto)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var oContacto = _ContactoDatos.Obtener(IdContacto);
            return View(oContacto);
        }
        [HttpPost]
        public IActionResult Editar(ContactoModel oContacto)
        {
            //MEOTODO RECIBE EL OBJETO PARA EDITAR EN BD
            if (!ModelState.IsValid)
            {
                return View();
            }
            var rpsta = _ContactoDatos.Editar(oContacto);
            if (rpsta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Eliminar(int IdContacto)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var oContacto = _ContactoDatos.Obtener(IdContacto);
            return View(oContacto);
        }
        [HttpPost]
        public IActionResult Eliminar(ContactoModel oContacto)
        {
            var rpsta = _ContactoDatos.Eliminar(oContacto.IdContacto);
            if (rpsta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
    }
}
