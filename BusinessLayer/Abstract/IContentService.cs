using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList();//List of content türünden
        List<Content> GetListByWriter(int id);//
        void ContentAdd(Content content);
        void ContentUpdate(Content content);
        void ContentDelete(Content content);
        Content GetById(int id);//content türünden getbyid metodu tanımladım
        List<Content> GetListByHeadingID(int id);
    }
}
