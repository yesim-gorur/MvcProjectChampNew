using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetList();//list of contact sınıfından getlist metodum var
        void ContactAdd(Contact contact);//yeni bir contact ekleme olayım var
        Contact GetById(int id);// eger bana bir contactın id si lazım olursa onu elde etmek için getbyid metodu kullanmam lazım
        void ContactDelete(Contact contact);    
        void ContactUpdate(Contact contact);
    }
}
