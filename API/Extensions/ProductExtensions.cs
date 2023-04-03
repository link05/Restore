using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Extensions
{
    public static class ProductExtensions
    {
        public static IQueryable<Product> Sort(this IQueryable<Product> query,
        string orderBy){
            if(string.IsNullOrWhiteSpace(orderBy)) return query.OrderBy(x=> x.Name);
            query = orderBy switch 
            {
                "price" => query.OrderBy(p => p.Price),
                "priceDesc" => query.OrderByDescending(p => p.Price),
                _ => query.OrderBy(x=> x.Name)
            };
            return query;
        }

        public static IQueryable<Product> Search(this IQueryable<Product> query, string searchTerm)
        {
            if(string.IsNullOrWhiteSpace(searchTerm)) return query;
            var lowerCaseSearchTerm = searchTerm.Trim().ToLower();

            return query.Where(x=> x.Name.ToLower().Contains(lowerCaseSearchTerm));
        }
    }
}