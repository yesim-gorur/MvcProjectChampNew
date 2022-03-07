using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAddBL(Category category)// son eklenen metod
        {
            _categoryDal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetByID(int id)
        {
            return _categoryDal.Get(x=>x.CategoryId==id);
        }

        //GenericRepository<Category> repo = new GenericRepository<Category>();
        //public List<Category> GetAllBL()
        //{ 
        // return repo.List();

        //}
        //public void CategoryAddBL(Category p)//category sınıfından bir p parametresi göndercem eklemek için
        //{


        //    if (p.CategoryName == "" || p.CategoryName.Length <= 3 ||
        //        p.CategoryDescription == "" || p.CategoryName.Length >= 51)
        //    {



        //    }
        //    else
        //    {

        //        repo.Insert(p);//dışardan gönderdiğim parametrem bunlardan herhangi
        //        //birinetakılmazsa insert edilecek
        //    }
        public List<Category> GetList()
        {
            return _categoryDal.List();
        }
    }

}

