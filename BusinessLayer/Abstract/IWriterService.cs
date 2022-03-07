using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetList();//yazarları listeleyebilmek için
        void WriterAdd(Writer writer);//yeni yazar ekleme için writer sınıfından writer türünden bir nesne alacaksın
        void WriterDelete(Writer writer);
        void WriterUpdate(Writer writer);
        Writer GetByIdD(int id);//writer türünde getbyid diye bir metod bazı işlemlerde id yi elde etmem için lazım

    }
}
