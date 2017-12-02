using System.ComponentModel.DataAnnotations;

namespace BravisWorkplanner.Data.Models
{
    public class WorkOrder
    {
        public int Id { get; set; }
        
        [Required, StringLength(100), Display(Name = "OBJ-NR")]
        public string Name { get; set; }

        [Required, StringLength(255), Display(Name = "Adress")]
        public string Address { get; set; }
        [StringLength(255), Display(Name = "Beskrivning")]
        public string Description { get; set; }
        [StringLength(255), Display(Name = "Start")]
        public string Start { get; set; }
        [StringLength(255), Display(Name = "Status")]
        public string Status { get; set; }
        [StringLength(255), Display(Name = "Fakturerat")]
        public string SentInvoice { get; set; }
    }
}