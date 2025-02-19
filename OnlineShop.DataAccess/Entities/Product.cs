using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DataAccess.Entities;

public abstract class BaseEntity
{
    public Guid Id { get;  set; }

    protected abstract void SetId();
}

public class Product :BaseEntity
{
    
    public string Name { get;private set; }

    public string Description { get;private set; }

    public decimal Price { get;private  set; }
   

    public Product(string name, string description, decimal price)
    {
        
        Description = description;
        SetName(name);
        SetPrice(price);
    }

    public void Updateproduct(string name,string description, decimal price )
    {
        SetName(name);
        SetPrice(price);
        Description = description;
    }


        public string GetName()
        {
            return Name;
        }

        public void SetName(string Name)
        {
            
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentException("اسم را وارد کنید");
            }
            
        }

        
        public decimal GetPrice() 
        {
            return Price;
        }

       
        public void SetPrice(decimal Price)
        {
            
            if (Price <= 1000)
            {
                throw new ArgumentException("قیمت را به درستی وارد کنید");
            }
         
        }

       
        public void DisplayInfo()
        {
            Console.WriteLine($"Product Name: {Name}, Price: {Price}");
        }

    protected override void SetId()
    {
      Id = Guid.NewGuid();
    }
}






