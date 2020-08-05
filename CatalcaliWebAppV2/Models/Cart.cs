using CatalcaliWebAppV2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalcaliWebAppV2.Models
{
    public class Cart
    {
        private List<CartLine> _cardLines = new List<CartLine>();
        private DataContext _context = new DataContext();
        public double shipping = 0;

        public List<CartLine> CartLines
        {
            get { return _cardLines; }
        }

        public void AddProduct(Product product, int quantity)
        {
            var line = _cardLines.FirstOrDefault(i => i.Product.ProductId == product.ProductId);
            if (line == null)
            {
                _cardLines.Add(new CartLine() { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void DeleteProduct(Product product)
        {
            _cardLines.RemoveAll(i => i.Product.ProductId == product.ProductId);
        }

        public double SubTotal()
        {
            return _cardLines.Sum(i => (i.Product.Price * i.Quantity));
        }

        public double Total()
        {
            return (shipping += _cardLines.Sum(i => i.Product.Price * i.Quantity));
        }

        public void Clear()
        {
            _cardLines.Clear();
        }

        public double ShippingFee()
        {
            Shipping shippings = _context.Shippings.FirstOrDefault(x => x.ShippingId == 1);
            return shipping = shippings.ShippingFee;
        }
    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public Shipping Shipping { get; set; }
    }
}