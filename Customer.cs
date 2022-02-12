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