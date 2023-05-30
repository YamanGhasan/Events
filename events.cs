using system;

namespace events
{
class program //subscriber 
  {
         static void Main(string[] args)
            {
 
           var stock = new Stock("Amazon");   // Creating a new Stock object with the name "Amazon"
           stock.Price = 100;
           
          // Subscribe to the OnPriceChanged event
          // When the OnPriceChanged event of the 'stock' object is raised, the 'Stock_OnPriceChanged' method  will be called to handle the event.
          stock.OnPriceChanged += Stock_OnPriceChanged;  
            stock.changeStockPriceBy(0.05m);
            stock.changeStockPriceBy(-0.02m);
           stock.ChangeStockPriceBy(0.00m);
            stock.OnPriceChanged -= Stock_OnPriceChanged; //     unsubscribe from the OnPriceChanged event
           
          // console.writeline($"Price before changing : ${stock.Price} ");
           
          // stock.changeStockPriceBy(0.05m);       // Changing the stock price by 5%    
           
         //  console.writeline($"Price after changing : ${stock.Price} ");
           
            }
  
  private static void  Stock_OnPriceChanged(stock stock ,decimal oldPrice) //method to call when event is published 
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
  
  
  public delegate void stockPriceChangeHandler(stock stock ,decimal oldPrice);  // Delegate for handling stock price changes
  
public class Stock   //publisher 
     { 
     private string name;
     private decimal price;
     
     public event stockPriceChangeHandler OnPriceChanged; //// Event triggered when the stock price changes

  
     public string Name =>this.name;        //get property Name 
     public decimal Price{ get=> this.price ;set => this.price = value ;}    //setter & getter for price 
  
  
  
  
  public Stock(string stockname)
  {
    this.name = stockname;           // the constructor initializes the name  property with the value  during object creation
  }
  
  
  public void changeStockPriceBy(decimal percent)
  {
    decimal oldPrice= this.price;  // value of old price 
    this.price += math.Round(this.price * percent ,2); //the percentage by which the stock price should be changed
    
    if (OnPriceChanged != null) //make sure there is subscriber 
    {
      OnPriceChanged(this,oldPrice);  // publishing event 
    }
  }
     }
}
