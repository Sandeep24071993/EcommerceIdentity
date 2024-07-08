using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorEcommerceIdentityProject.Data;
using RazorEcommerceIdentityProject.Models;

namespace RazorEcommerceIdentityProject.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty] // only one property bind
        public Category category { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            category = _db.Categories.Find(id);
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                TempData["success"] = "Category Updeted successfully";
                return RedirectToPage("Index");
            }
           return Page();   
        }
    }
}
