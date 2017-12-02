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
    public class IndexModel : PageModel
    {
        private readonly BravisDbContext _db;

        public IndexModel(BravisDbContext db)
        {
            _db = db;
        }

        public IList<WorkOrder> WorkOrders { get; set; }

        [TempData]
        public string Message { get; set; }
        public bool HasMessage => !string.IsNullOrEmpty(Message);
        public bool HasWorkorders => WorkOrders.Count > 0;
        public async Task OnGetAsync(string searchString)
        {
            var workOrders = from w in _db.WorkOrders
                             select w;

            if (!string.IsNullOrEmpty(searchString))
            {
                workOrders = _db.WorkOrders.Where(w => w.Description.Contains(searchString));
            }

            WorkOrders = await workOrders.ToListAsync();
        }
        
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            _db.WorkOrders.Attach(new WorkOrder { Id = id}).State = EntityState.Deleted;
            await _db.SaveChangesAsync();

            Message = $"Workorder {id} was deleted successfully";
            return RedirectToPage();
        }
    }
}
