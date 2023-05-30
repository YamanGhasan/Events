using system;

namespace events
{
class program
  {
         static void Main(string[] args)
            {
 
           var stock = new Stock("Amazon");   // Creating a new Stock object with the name "Amazon"
           stock.Price = 100;
           console.writeline($"Price before changing : ${stock.Price} ");
           
           stock.changeStockPriceBy(0.05m);       // Changing the stock price by 5%    
           
           console.writeline($"Price after changing : ${stock.Price} ");
           
            }
}
  
  
  public delegate void stockPriceChangeHandler(stock stock ,decimal oldPrice);  // Delegate for handling stock price changes
public class Stock
     { 
     private string name;
     private decimal price;
     
     public string Name =>this.name;        //get property Name 
     public decimal Price{ get=> this.price ;set => this.price = value ;}    //setter & getter for price 
  
  
  
  
  public Stock(string stockname)
  {
    this.name = stockname;           // the constructor initializes the name  property with the value  during object creation
  }
  
  
  public void changeStockPriceBy(decimal percent)
  {
    this.price += math.Round(this.price * percent ,2); //the percentage by which the stock price should be changed
  }
     }
}
