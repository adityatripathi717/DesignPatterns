using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class Stock : IStock
    {
        public List<IObserver> Observers = new List<IObserver>();

        public int stockPrice;

        public int StockPrice
        {
            get { return stockPrice; }
            set
            {
                if (stockPrice != value)
                {
                    stockPrice = value;
                    Notify();
                }
            }
        }

        public void Attach(IObserver ob)
        {
            Observers.Add(ob);
        }

        public void Detach(IObserver ob)
        {
            Observers.Remove(ob);
        }

        public void Notify()
        {
            foreach (var ob in Observers)
            {
                ob.Update(stockPrice);
            }
        }
    }
}
