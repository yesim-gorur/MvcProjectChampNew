using DataAccessLayer.Concrete.Repositories;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        GenericRepository<Category> repo = new GenericRepository<Category>();
        public List<Category> GetAll()
        { 
         return repo.List();
        
        }
        public void CategoryAddBL(Category p)//category sınıfından bir p parametresi göndercem eklemek için
        {
            if (p.CategoryName == "" || p.CategoryName.Length <= 3 ||
                p.CategoryDescription == "" || p.CategoryName.Length >= 51)
            { 
            
            
            
            }
            else
            {

                repo.Insert(p);//dışardan gönderdiğim parametrem bunlardan herhangi
                //birinetakılmazsa insert edilecek
            }
       
        
        }

    }
}
