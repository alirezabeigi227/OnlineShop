using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DataAccess.Entities
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public DateTime InvoiceDate { get; set; }

       

        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

       public virtual List<InvoiceItem> InvoiceItems { get; set; }
        
    }
}
