using System;
using System.Collections.Generic;

namespace polyglots.practice._2022
{
    public class CustomerDictionary
    {
        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
            foreach (string like in customer.Likes)
            {
                likes.Add(like);
            }
            foreach (string dislike in customer.Dislikes)
            {
                dislikes.Add(dislike);
            }
        }

        public List<Customer> customers { get; set; }
        public List<String> likes { get; set; }
        public List<String> dislikes { get; set; }
    }
}
