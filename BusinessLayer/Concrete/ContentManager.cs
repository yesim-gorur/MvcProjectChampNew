using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;


        }

        public void ContentAdd(Content content)
        {
            _contentDal.Insert(content); //burdaki insert>Icontentdal>Irepository>genericrepositoryde doluyor içi
        }

        public void ContentDelete(Content content)
        {
            _contentDal.Delete(content);
        }

        public void ContentUpdate(Content content)
        {
            _contentDal.Update(content);
        }

        public Content GetById(int id)
        {
            return _contentDal.Get(x=>x.ContentId==id);
            //getbyid idsine göre getir demek eger x.contentid parametredeki diğer id ye eşitse
        }

        public List<Content> GetList()
        {
            throw new NotImplementedException();//hata fırlatmasın die
        }

        public List<Content> GetListByHeadingID(int id)
        {
            //dışardan alacağın id ye göre listeleme işi yapacaksın
            return _contentDal.List(x => x.HeadingId == id);
            
        }

        
    }
}
