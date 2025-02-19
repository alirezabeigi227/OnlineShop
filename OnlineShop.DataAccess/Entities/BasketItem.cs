using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DataAccess.Entities
{
    public class BasketItem
    {
        [Key]
        public int Id { get; set; }

        public decimal price { get; set; }

        public int Quantity { get; set; } //تعداد

        public int BasketId { get; set; }

        [ForeignKey(nameof(BasketId))]
        public Basket Basket { get; set; }

        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }



       // public BasketItem(decimal price , int Quantity , int Id)
       // {
       //     SetPrice(price);
       //     SetQuantity(Quantity);
       //     GetId(Id);
       // }

       // public int GetId(int id)
       // {
       //     return Id;
       // }


       // public decimal GetPrice()
       // {
       //     return price;
       // }
       // public void SetPrice(decimal Price)
       // {

       //     if (Price <= 1000)
       //     {
       //         throw new ArgumentException("قیمت را به درستی وارد کنید");
       //     }

       // }
       // public int GetQuantity() { return Quantity; }

       // public void SetQuantity(int Quantity)
        
       //{ 
       //     if (Quantity <=0)
       //     {
       //         throw new ArgumentException("تعداد را به درستی وارد کنید");
       //     }

       // }


    }
}
