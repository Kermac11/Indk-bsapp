using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indkøbsapp.Interfaces;

namespace Indkøbsapp.Models
{
    public class OrderItem
    {
        //Denne klasse bruges til at lave et nyt objekter så vi kan se hvor mange af det objekter der er i en ordrer
        public OrderItem(IButikItems item)
        {
            Item = item;
        }

        //indeholder selve varen der købes
        public IButikItems Item { get; set; }

        //Bruges til at vise hvor mange af den varer der ekisitere i ordreren
        public int Amount { get; set; }
    }
}
