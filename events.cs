// events between 2 classes without UI 
using System; 






namespace events
{
    class Program // Subscriber - receives or handles the event
    {
        static void Main(string[] args)
        {
            var stock = new Stock("Amazon"); // Creating a new Stock object with the name "Amazon"
            stock.Price = 100;

            // Subscribe to the OnPriceChanged event
            // When the OnPriceChanged event of the 'stock' object is raised, the 'Stock_OnPriceChanged' method will be called to handle the event.
            stock.OnPriceChanged += Stock_OnPriceChanged;

            stock.ChangeStockPriceBy(0.05m);
            stock.ChangeStockPriceBy(-0.02m);
            stock.ChangeStockPriceBy(0.00m);
            stock.OnPriceChanged -= Stock_OnPriceChanged; // Unsubscribe from the OnPriceChanged event
        }

        private static void Stock_OnPriceChanged(Stock stock, decimal oldPrice) // Method to call when event is published  --  this is the event handler 
         //it is the method that gets called when the OnPriceChanged event is raised
        {
            string result = "";
            
            if (stock.Price > oldPrice)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                result = "up";
            }
            else if (oldPrice > stock.Price)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                result = "down";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.WriteLine($"{stock.Name}: ${stock.Price} - {result}");
        }
    }

    public delegate void stockPriceChangeHandler(Stock stock, decimal oldPrice); // Delegate for handling stock price changes

    
    
    public class Stock // Publisher that raises the event
    {
        private string _name;
        private decimal _price;

        public event stockPriceChangeHandler OnPriceChanged; // Event triggered when the stock price changes

        public string Name => this._name; // Get property Name

        public decimal Price { get => this._price; set => this._price = value; } // Setter & getter for price

        public Stock(string stockname)
        {
            this._name = stockname; // The constructor initializes the name property with the value during object creation
        }

        public void ChangeStockPriceBy(decimal percent)
        {
            decimal oldPrice = this.price; // Value of old price
            this.price += Math.Round(this.price * percent, 2); // The percentage by which the stock price should be changed

            if (OnPriceChanged != null) // Make sure there is a subscriber
            {
                OnPriceChanged(this, oldPrice); // Publish or raise the event by invoking the event
            }
        }
    }
}

