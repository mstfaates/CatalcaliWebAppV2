using CatalcaliWebAppV2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalcaliWebAppV2.Repository
{
    public class ProductRepository : GenericRepository<Product, int>
    {
        DataContext _context = null;
        ProcessResult<Product> result = new ProcessResult<Product>();
        public override Result<int> Create(Product item)
        {
            using (_context = new DataContext())
            {
                _context.Products.Add(item);
                return result.GetResult(_context);
            }
        }

        public override Result<int> Delete(int id)
        {
            using (_context = new DataContext())
            {
                Product toBeDeleted = _context.Products.FirstOrDefault(x => x.ProductId == id);
                _context.Products.Remove(toBeDeleted);
                return result.GetResult(_context);
            }
        }

        public override Result<List<Product>> GetAll()
        {
            using (_context = new DataContext())
            {
                return result.GetList(_context.Products.ToList());
            }
        }

        public override Result<Product> GetById(int id)
        {
            using (_context = new DataContext())
            {
                return result.GetT(_context.Products.FirstOrDefault(x => x.ProductId == id));
            }
        }

        public override Result<List<Product>> GetLatest(int quantity)
        {
            using (_context = new DataContext())
            {
                return result.GetList(_context.Products.OrderByDescending(x => x.ProductId).Take(quantity).ToList());
            }
        }

        public override Result<int> Update(Product item)
        {
            using (_context = new DataContext())
            {
                Product toBeUpdate = _context.Products.FirstOrDefault(x => x.ProductId == item.ProductId);
                toBeUpdate.Name = item.Name;
                toBeUpdate.Price = item.Price;
                toBeUpdate.Description = item.Description;
                toBeUpdate.Stock = item.Stock;
                toBeUpdate.IsApproved = item.IsApproved;
                toBeUpdate.IsHome = item.IsHome;
                toBeUpdate.Category = item.Category;
                toBeUpdate.Image = item.Image;
                toBeUpdate.ImageDescription = item.ImageDescription;
                toBeUpdate.Weight = item.Weight;
                return result.GetResult(_context);
            }
        }
    }
}
