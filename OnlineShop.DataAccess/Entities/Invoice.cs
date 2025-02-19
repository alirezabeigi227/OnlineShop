using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DataAccess.Entities
{

    public class Invoice 
    {
        [Key]
        public int Id { get; set; }

        public string Title { get;private set; }

        public string Description { get;private set; }

        public string Address { get;private set; }

        public DateTime InvoiceDate { get; set; }

       

        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

       public virtual List<InvoiceItem> InvoiceItems { get; set; }


        public Invoice(string Title, string Description, string Address)
        {
            SetTitle(Title);
            SetDescription(Description);
            SetAddress(Address);
        }
        public void Updateinvoice(string Title, string Description, string Address)
        {
            SetTitle(Title);
            SetDescription(Description);
            SetAddress(Address);
        }

        public string GetTitle()
        {
            return Title;
        }

        public void SetTitle(string Title)
        {

            if (string.IsNullOrWhiteSpace(Title))
            {
                throw new ArgumentException("موضوع را وارد کنید");
            }

        }

        public string GetDescription()
        {
            return Description;
        }

        public void SetDescription(string Description)
        {

            if (string.IsNullOrWhiteSpace(Description))
            {
                throw new ArgumentException("موضوع مورد نظر را وارد کنید");
            }

        }


        public string GetAddress()
        {
            return Address;
        }

        public void SetAddress(string Address)
        {

            if (string.IsNullOrWhiteSpace(Address))
            {
                throw new ArgumentException("آدرس مورد نظر را وارد کنید");
            }

        }


    }
}
