using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public List<BasketItem> Items {get;set;} = new List<BasketItem>();

        public void AddItem(Product product, int quantity)
        {
            if(Items.All(item => item.ProductId != product.Id))
            {
                Items.Add(new BasketItem {Product = product, Quantity  = quantity});
            }else{
                var existingItem = Items.FirstOrDefault(item => item.ProductId == product.Id);
                if(existingItem != null)
                {
                    existingItem.Quantity += quantity;
                }
            }
            
        }

        public void RemoveItem(int ProductId, int Quantity)
        {
            Console.WriteLine("productId in removeItem!!"+ProductId);

            var item = Items.FirstOrDefault(x=> x.ProductId == ProductId);
            if(item == null)return;
            item.Quantity -= Quantity;
            if(item.Quantity == 0) Items.Remove(item);
        }
    }
}