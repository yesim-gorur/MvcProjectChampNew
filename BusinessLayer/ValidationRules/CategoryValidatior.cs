using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CategoryValidatior:AbstractValidator<Category>
    {

        public CategoryValidatior()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("kategori alanını boş geçemezsiniz");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("kategori açıklama alanını boş geçemezsiniz");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("lütfen en az 3 karakter girişi yapın");
            RuleFor(x => x.CategoryName).MinimumLength(21).WithMessage("lütfen en fazla 21 karakter girişi yapın");
        }
    }
}
