// See https://aka.ms/new-console-template for more information

using ClassLibrary1;

namespace AS.Console{
     public class Program{
        public static void InputProduct(ref string product){
            while (product == ""){
                System.Console.Write("Please type in your product name: ");
                product = System.Console.ReadLine() ?? "";
            }
        }

        public static void InputPrice(out double price){
            price = 0;
            
            while (price <= 0)
            {
                try
                {
                    System.Console.Write("Please type in your product price: ");
                    price = Double.Parse(System.Console.ReadLine());

                    if (price <= 0)
                        System.Console.WriteLine("Price has to be greater than 0.");
                }
                catch
                {
                    System.Console.WriteLine("Product has to be numerical.");
                }

            }
        }

        public static void Output(string product, double price, int qnt = 0){
            System.Console.WriteLine("Product name: " + product);
            System.Console.WriteLine("Product price: " + price);
            
            if(qnt != 0)
                System.Console.WriteLine("Quantity: " + qnt);
        }

        public static void Main(string[] args){
            Provider bassem = new Provider("Bassem","123456","123456","bassem.jadoui@esprit.tn");

            // System.Console.WriteLine(bassem.Login("Bassem", "123456"));
            // System.Console.WriteLine(bassem.Login("Bassem", "123456","bassem.jadoui@esprit.tn"));

    
            bool? isApproved = false;
            Provider.SetIsApproved(bassem, out isApproved);
            // System.Console.WriteLine(product);

        
            Product product = new Product();
            Chemical chemicalProduct = new Chemical();
            Biological biologicalProduct = new Biological();
            
            product.getMyType();
            chemicalProduct.getMyType();
            biologicalProduct.getMyType();
            
            // bassem.GetDetails();

            
        }
    }
}