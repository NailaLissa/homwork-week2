
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Xml.Linq;
// creating a List Object 
ProductList productList = new ProductList();

// To start the program, Enter value to choose 
while (true)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("To enter a new product - enter: p | To search a product- enter: s | To quite - enter: p");
    string input = Console.ReadLine().ToLower();

    switch (input)
    {

        // to add product, call the methods from productList-class
        case "p":
            productList.AddProduct();
            break;
        // to search for a product name, call the methods from productList-class

        case "s":
          productList.SearchProduct();
            break;
                // to finish adding and print the table of product


        case "q":
            Console.WriteLine("----------------------------------------------");
            productList.PrintList();
            break;

            // Error message in case wrong input
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid choice. Please enter a valid option.");
            break;
    }
    


        }


// create class for object Product

class Product
{
    public Product()
    {
    }

    public Product(string gategory, string name, int price)
    {
        Gategory = gategory;
        Name = name;
        Price = price;
    }

    public string Gategory { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
}


// create ProductList class and the Methods 
class ProductList
{
    private List<Product> products = new List<Product>();

    // creat a Method to add new Product to the List.
    public void AddProduct()
    {

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" Enter a category: ");
        string category = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" Enter a product Name:");
        string name = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White; Console.Write(" Enter a price: ");
        string number = Console.ReadLine();
        bool isInt = int.TryParse(number, out int value);
        if (isInt)
        {
            
            int price = Convert.ToInt32(number);
            if (price > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" the product was succefully added!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("----------------------------------------------");
                products.Add(new Product(category, name, price));
            }else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Its not a positive number");
               
            }
            
        } else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" you must enter number");
            
        }
    }
   

    // create Method to Print all the Product in the List
    public void PrintList()
    {

        Console.ForegroundColor = ConsoleColor.White;
        // Sorted the the List befor display 

        List<Product> sortedList = products.OrderBy(Product => Product.Price).ToList();
        Console.WriteLine("your List of Product");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Gategory".PadRight(15) + "Name".PadRight(15) + "Price");

        // loop to Print all the product in the List 

        foreach (Product product in sortedList)
        {

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(product.Gategory.PadRight(15) + product.Name.PadRight(15) + product.Price);

        }
        Console.WriteLine(" Total amount: ".PadLeft(30) + products.Sum(Product => Product.Price));


        Console.WriteLine("----------------------------------------------");
    }

    // Create a Method to search for a Product using name.
    public void SearchProduct()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Enter product name to search:");
        string searchName = Console.ReadLine();

        // filter the List by searching for product name .
        List<Product> filteredProducts = products.Where(product => product.Name.ToLower().Contains(searchName.ToLower())).ToList();

        // condition if there is no mathced product
        if (filteredProducts.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Product not found.");
        }
       
        // if it found the product name , print all the list and highlight the Product that is found.
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Search results:");
            Console.WriteLine("----------------");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Gategory".PadRight(15) + "Name".PadRight(15) + "Price");


            List<Product> sortedList = products.OrderBy(Product => Product.Price).ToList();
            foreach (Product product in sortedList)
            {
                if (product.Name.ToLower().Contains(searchName.ToLower()))
                {

                    Console.ForegroundColor = ConsoleColor.Magenta;

                }
                else
                { Console.ForegroundColor = ConsoleColor.White; }
                
                Console.WriteLine(product.Gategory.PadRight(15) + product.Name.PadRight(15) + product.Price);

            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------------------------");
        }
    }
}

        














