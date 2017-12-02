using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BravisWorkplanner.Data;
using BravisWorkplanner.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BravisWorkplanner.Pages
{
    public class CreateModel : PageModel
    {
        private readonly BravisDbContext _db;

        [TempData]
        public string Message { get; set; }
        public bool HasMessage => !string.IsNullOrEmpty(Message);

        [BindProperty]
        public WorkOrder WorkOrder { get; set; }
        public CreateModel(BravisDbContext db)
        {
            _db = db;
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Message = "Something went wrong when trying to delete the record.";
                return Page();
            }

            _db.WorkOrders.Add(WorkOrder);
            await _db.SaveChangesAsync();
            
            Message = "Successfully created a new record.";
            return RedirectToPage("/Index");
        }
    }
}