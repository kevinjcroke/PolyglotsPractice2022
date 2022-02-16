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
                if (!fullToppings.Contains(like))
                {
                    fullToppings.Add(like);
                }
                if (!likes.ContainsKey(like))
                {
                    likes.Add(like, 1);
                }
                else
                {
                    likes[like] = likes[like]++;
                }
            }
            foreach (string dislike in customer.Dislikes)
            {
                if (!fullToppings.Contains(dislike))
                {
                    fullToppings.Add(dislike);
                }
                if (!dislikes.ContainsKey(dislike))
                {
                    dislikes.Add(dislike, 1);
                }
                else
                {
                    dislikes[dislike] = dislikes[dislike]++;
                }
            }
        }

        public List<Customer> customers { get; set; } = new List<Customer>();
        public List<String> fullToppings { get; set; } = new List<String>();
        public Dictionary<String, int> likes { get; set; } = new Dictionary<string, int>();
        public Dictionary<String, int> dislikes { get; set; } = new Dictionary<string, int>();

        public int numberOfCustomers
        {
            get
            {
                return customers.Count;
            }
        }

        public bool isMoreLikedThanDisliked(String topping)
        {
            if (!likes.TryGetValue(topping, out int likeCount))
            {
                likeCount = 0;
            }

            if (!dislikes.TryGetValue(topping, out int dislikeCount))
            {
                dislikeCount = 0;
            }
            return likeCount > dislikeCount;
        }

        public List<String> ToppingsRatio(int ratio)
        {
            List<String> toppings = new List<String>();
            foreach (String topping in fullToppings)
            {
                if (isMoreLikedThanDisliked(topping) && isDislikedLessThan(topping, ratio))
                {
                    toppings.Add(topping);
                }
            }

            return toppings;
        }

        public bool isDislikedLessThan(String topping, int ratio)
        {
            if (!dislikes.TryGetValue(topping, out int dislikeCount))
            {
                dislikeCount = 0;
            }

            return dislikeCount <= (ratio / 100) * numberOfCustomers;
        }
    }
}