using System;
using System.IO;
using System.Collections.Generic;

namespace polyglots.practice._2022
{
    class Program
    {
        static void Main(string[] args)
        {
            string textFile = "files/a_an_example.in.txt";
            string[] lines = File.ReadAllLines(textFile);

            CustomerDictionary customerDictionary = new CustomerDictionary();

            for (int i = 1; i < lines.Length - 1; i += 2)
            {
                var newCustomer = new Customer(lines[i], lines[i + 1]);
                customerDictionary.AddCustomer(newCustomer);
            }

            foreach (Customer customer in customerDictionary.customers)
            {
                Console.WriteLine(customer);
            }
        }
    }
}
