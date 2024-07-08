using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorEcommerceIdentityProject.Data;
using RazorEcommerceIdentityProject.Models;

namespace RazorEcommerceIdentityProject.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty] // only one property bind
        public Category category { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                category = _db.Categories.Find(id);
            }
        }
        public IActionResult OnPost()
        {
            Category? ctg = _db.Categories.Find(category.Id); ;
            if (ctg == null)
            {
                return NotFound();
            }
                _db.Categories.Remove(ctg);
                _db.SaveChanges();
            TempData["success"] = "Category Delete successfully";
            return RedirectToPage("Index");
           
        }
    }
}
