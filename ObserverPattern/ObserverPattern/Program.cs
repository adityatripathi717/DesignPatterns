namespace ObserverPattern
{



    internal class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock();

            Subscriber S1 = new Subscriber("John");
            Subscriber S2 = new Subscriber("Tom");
            Subscriber S3 = new Subscriber("Som");

            stock.Attach(S1);
            stock.Attach(S2);
            stock.Attach(S3);


            stock.StockPrice = 1000;
            stock.StockPrice = 2000;



        }
    }
}
