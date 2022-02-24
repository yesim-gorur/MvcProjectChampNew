using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        //tüm sınıflar için IRepository tanımladım sonra buraya metod imzalarını yazdım
        //sonra sınıflarımı IRepositoryden inherit ettim
        //şimdi ise bu metodların işlevlerini yazabilecegim Generic Repositorye ihtiyacım var
        Context c=new Context();
        DbSet<T> _object;
        public GenericRepository()
        {
            _object=c.Set<T>();//_object isimli fieldim dışardan gönderilen deger ne ise olacak
        }
        
        
        public void Delete(T p)
        {
            _object.Remove(p);//silme işlemini yap
            c.SaveChanges();// değişiklikleri kaydet context üzerinden 
        }

        public void Insert(T p)
        {
            _object.Add(p);
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();//ToList falan entity framework metodlarıdır.

        }

        public List<T> List(Expression<Func<T, bool>> filter)//şartlı listeleme
            //tüm özellikleri aynı sadeceList in içinde şart var
        {
            return _object.Where(filter).ToList();//listele ama where filter yap
        }

        public void Update(T p)
        {
            c.SaveChanges();
        }
    }
}
