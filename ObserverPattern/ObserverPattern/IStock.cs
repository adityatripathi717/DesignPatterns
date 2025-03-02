using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public interface IStock
    {
        void Attach(IObserver ob);
        void Detach(IObserver ob);
        void Notify();

    }
}
