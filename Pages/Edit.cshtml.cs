using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BravisWorkplanner.Data;
using BravisWorkplanner.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BravisWorkplanner.Pages
{
    public class EditModel : PageModel
    {
        private readonly BravisDbContext _db;
        public EditModel(BravisDbContext db)
        {
            _db = db;
        }

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public WorkOrder WorkOrder { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WorkOrder = await _db.WorkOrders.SingleOrDefaultAsync(w => w.Id == id);

            if (WorkOrder == null)
            {
                return NotFound();
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Attach(WorkOrder).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
                Message = "Workorder successfully edited.";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.WorkOrders.Any(w => w.Id == WorkOrder.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
    }
}