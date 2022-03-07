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
            var deletedEntitiy=c.Entry(p);
            deletedEntitiy.State=EntityState.Deleted;
           // _object.Remove(p);//silme işlemini yap
            c.SaveChanges();// değişiklikleri kaydet context üzerinden 
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);//bir dizide veya listede sadece 1 deger döndürmek için etity linq
        }//ör:Id si 5 olanı döndür

        public void Insert(T p)
        {
            var addedEntity = c.Entry(p);
            addedEntity.State = EntityState.Added;
           // _object.Add(p);
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();//ToList falan entity framework metodlarıdır.

        }

        public List<T> List(Expression<Func<T, bool>> filter)//şartlı listeleme
            //tüm özellikleri aynı sadeceList in içinde şart var
            //ismi ali olanları listele
        {
            return _object.Where(filter).ToList();//listele ama where filter yap
        }

        public void Update(T p)
        {
            var updatedEntity = c.Entry(p);
            updatedEntity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
