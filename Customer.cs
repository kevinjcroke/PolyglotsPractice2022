using System;
using System.Collections.Generic;
using System.Linq;

namespace polyglots.practice._2022
{
    public class Customer
    {
        public Customer(string likes, string dislikes)
        {
            Likes = Parse(likes);
            Dislikes = Parse(dislikes);
        }

        public bool LikesPizza(string pizza)
        {
            var toppings = pizza.Split(" ").Skip(1);
            if (!Likes.All(t => toppings.Contains(t)))
            {
                return false;
            }

            if (toppings.Any(t => Dislikes.Contains(t)))
            {
                return false;
            }

            return true;
        }

        private List<string> Parse(string preferences)
        {
            var retVal = new List<string>();

            var prefList = preferences.Split(" ");
            for (int i = 1; i < prefList.Count(); i++)
            {
                retVal.Add(prefList[i]);
            }

            return retVal;
        }

        public List<string> Likes { get; set; }
        public List<string> Dislikes { get; set; }

        public override string ToString()
        {
            return $"Likes ({Likes.Count()}): {String.Join(" ", Likes)}\r\nDislikes ({Dislikes.Count()}): {String.Join(" ", Dislikes)}";
        }
    }

}