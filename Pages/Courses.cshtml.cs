using System.Collections.Generic;
using System.Threading.Tasks;
using ListaCursos.Interfaces;
using ListaCursos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ListaCursos.Pages
{
    public class CoursesModel : PageModel
    {
        private readonly ICoursesProvider coursesProvider;

        public List<Course> Courses { get; set; }

        public CoursesModel(ICoursesProvider coursesProvider)
        {
            this.coursesProvider = coursesProvider;
        }

        /// <summary>
        /// Se ejecuta este m�todo cuando se hace una petici�n GET
        /// </summary>
        public async Task<IActionResult> OnGet()
        {
            var results = await coursesProvider.GetAllAsync();
            if(results != null)
            {
                Courses = new List<Course>(results);
            }

            return Page();
        }
    }
}