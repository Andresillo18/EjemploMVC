using EjemploMVC.Data;
using EjemploMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploMVC.Controllers
{
    public class LibrosController : Controller
    {

        private readonly contextoAplicacion _context;

        // CONSTRUCTOR:
        public LibrosController(contextoAplicacion context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            IEnumerable<Libro> listaLibros = _context.Libro;
            // Es es equivalente a hacer un SELECT * FROM LIBROS

            return View(listaLibros);
        }

        // Método (acción) que se invoca al hacer una petición GET
        // desde la vista Index, cuando se de clic al botón Agregar nuevo libro

        [HttpGet]
        public IActionResult CreateGET()
        {
            return View("CrearLibro");
        }

        // Método (acción) POST, se ejecuta desde el formulario, en la vista CrearLibro


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePOST(Libro libro)
        {
            if (ModelState.IsValid) {
                _context.Libro.Add(libro);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("CrearLibro");
        }

        // GET de EDIT
        public IActionResult Edit(int? id) 
        {
            if (id == null || id < 1) {
                return NotFound();
            }

            // Obtener el libro para pasárselo a la vista Edit
            Libro libro = _context.Libro.Find(id);

            if (libro == null) {
                return NotFound();
            }

            return View(libro);
        }

        // POST DE EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Libro.Update(libro);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET de Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }

            // Obtener el libro para pasárselo a la vista Edit
            Libro libro = _context.Libro.Find(id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST de DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Libro libro = _context.Libro.Find(id);
            if (libro == null) {
                return NotFound();
            }

            _context.Libro.Remove(libro);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
