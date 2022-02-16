using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace polyglots.practice._2022
{
    class Program
    {

        static async Task Main(string[] args)
        {
            CustomerDictionary customerDictionary = await WriteFile("a_an_example.{0}.txt");
            await WriteFile("b_basic.{0}.txt");
            await WriteFile("c_coarse.{0}.txt");
            await WriteFile("d_difficult.{0}.txt");
            await WriteFile("e_elaborate.{0}.txt");

            foreach (Customer customer in customerDictionary.customers)
            {
                Console.WriteLine(customer);
            }
        }

        private static async Task<CustomerDictionary> WriteFile(string textFileFormat)
        {
            string[] lines = File.ReadAllLines($"files/{string.Format(textFileFormat, "in")}");

            CustomerDictionary customerDictionary = new CustomerDictionary();
            List<Customer> customers = new List<Customer>();

            for (int i = 1; i < lines.Length - 1; i += 2)
            {
                var newCustomer = new Customer(lines[i], lines[i + 1]);
                customerDictionary.AddCustomer(newCustomer);
                customers.Add(newCustomer);
            }

            var strategy = new RatioStrategy(100);

            var result = strategy.GetPizza(customerDictionary);
            Console.WriteLine($"{textFileFormat} {customers.Count(c => c.LikesPizza(result))}");

            await File.WriteAllTextAsync($"Results/{string.Format(textFileFormat, "out")}", result);
            return customerDictionary;
        }
    }
}
