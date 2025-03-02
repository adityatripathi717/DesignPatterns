using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class Subscriber : IObserver 
    {
        public int stockPrice;
        public string Name {  get; set; }
        public Subscriber(string name)
        {
            Name = name;
        }
       public void Update(int price)
        {
            stockPrice = price;

            Console.WriteLine($"{Name} Price updated to {stockPrice}");
        }
    }
}
