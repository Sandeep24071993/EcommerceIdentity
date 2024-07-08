using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorEcommerceIdentityProject.Data;
using RazorEcommerceIdentityProject.Models;

namespace RazorEcommerceIdentityProject.Pages.Categories
{
    //[BindProperties] for all property bind
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty] // only one property bind
        public Category category { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                TempData["success"] = "Category Created successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
