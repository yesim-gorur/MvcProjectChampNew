using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
//category repository sınıfım içinher bir metodun görevini yazdım
namespace DataAccessLayer.Concrete.Repositories
{
    public class CategoryRepository : ICategoryDal
    {
        Context c = new Context(); //context sınıfını kullanmam lazım çünkü tablolarım burada
        DbSet<Category> _object; //ordaki propları DbSet<> seklinde tuttugum için burdan bir nesne türetiyorum
        
        public void Delete(Category p)
        {
            _object.Remove(p);//nesneyi kaldır
            c.SaveChanges(); //kontext in içini kaydet değişiklikleri kaydet
        }

        public void Insert(Category p)
        {
            _object.Add(p);
            c.SaveChanges();
        }

        public List<Category> List()
        {
            return _object.ToList();
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Category p)
        {
            c.SaveChanges();
        }
    }
}
