using System;
using System.Collections.Generic;
using System.Linq;

namespace polyglots.practice._2022
{
    public class OnlyLikedStrategy : IStrategy
    {
        public string GetPizza(CustomerDictionary customerDictionary)
        {
            var likes = customerDictionary.customers.SelectMany(c => c.Likes).Distinct();
            var dislikes = customerDictionary.customers.SelectMany(c => c.Dislikes).Distinct();
            var onlyLikes = likes.Except(dislikes);

            return $"{onlyLikes.Count()} {string.Join(' ', onlyLikes)}";
        }
    }
}