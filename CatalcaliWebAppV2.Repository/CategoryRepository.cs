using CatalcaliWebAppV2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalcaliWebAppV2.Repository
{
    public class CategoryRepository : GenericRepository<Category, int>
    {
        DataContext _context = null;
        ProcessResult<Category> result = new ProcessResult<Category>();

        public override Result<int> Create(Category item)
        {
            using (_context = new DataContext())
            {
                _context.Categories.Add(item);
                return result.GetResult(_context);
            }
        }

        public override Result<int> Delete(int id)
        {
            using (_context = new DataContext())
            {
                Category toBeDeleted = _context.Categories.SingleOrDefault(x => x.Id == id);
                _context.Categories.Remove(toBeDeleted);
                return result.GetResult(_context);
            }
        }

        public override Result<List<Category>> GetAll()
        {
            using (_context = new DataContext())
            {
                List<Category> categoryList = _context.Categories.ToList();
                return result.GetList(categoryList);
            }
        }

        public override Result<Category> GetById(int id)
        {
            using (_context = new DataContext())
            {
                return result.GetT(_context.Categories.SingleOrDefault(x => x.Id == id));
            }
        }

        public override Result<List<Category>> GetLatest(int quantity)
        {
            throw new NotImplementedException();
        }

        public override Result<int> Update(Category item)
        {
            using (_context = new DataContext())
            {
                Category toBeUpdate = _context.Categories.SingleOrDefault(x => x.Id == item.Id);
                toBeUpdate.Name = item.Name;
                toBeUpdate.Description = item.Description;
                return result.GetResult(_context);
            }
        }
    }
}
