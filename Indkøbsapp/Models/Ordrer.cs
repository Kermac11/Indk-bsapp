using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Interfaces;

namespace Indkøbsapp.Models
{
    public class Ordrer : IOrdrer
    {

        //Liste der indeholder alle vare
        public List<OrderItem> Order { get; set; }

        //Viser hvem køber er
        public Bruger Buyer { get; set; }

        //Id til at identificere senere
        public int ID { get; set; }

        //Viser den totale pris på ordren
        public double Price
        {
            get;
            set;
        }

        // viser hvor mange vare der er i ordren
        public int AntalVarerIOdrer { get; set; }

        //Constructor der starter en ny liste til at indeholde vare
        public Ordrer()
        {
            Order = new List<OrderItem>();
        }

        // tilføjer en vare og laver og tjekker om den varer allerede ekisitere i ordren, og hvis den gør pluser den amount med en istedet for at lave et nyt objekt.
        public void AddItem(ButikItems item)
        {
            bool exist = false;
            foreach (OrderItem i in Order)
            {
                if (i.Item.ID == item.ID)
                {
                    i.Amount += 1;
                    Price += i.Item.Price;
                    AntalVarerIOdrer += 1;
                    exist = true;
                }
            }

            if (exist == false)
            {
                OrderItem p = new OrderItem(item);
                p.Amount = 1;
                Price += p.Item.Price;
                AntalVarerIOdrer += 1;
                Order.Add(p);
            }

        }

        //Fjerner en vare men tjekker også om dens amount er 1, og hvis den er en bliver varen fjernet helt istedet for bare at mindske amount til nul.
        public void DeleteItem(int id)
        {
            OrderItem check = null;
            foreach (OrderItem item in Order)
            {
                if (item.Item.ID == id)
                {
                    check = item;
                    item.Amount -= 1;
                    Price -= item.Item.Price;
                    AntalVarerIOdrer -= 1;
                }
            }

            if (check != null && check.Amount == 1)
            {
                Price -= check.Item.Price;
                Order.Remove(check);
            }
        }

        //regner prisen ud på ordreren
        public double CalculatePrice()
        {
            double price = 0;
            foreach (OrderItem item in Order)
            {
                price = item.Amount * item.Item.Price;
            }

            return price;
        }
    }
}
