using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail adresini boş geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("konu alanını boş geçemezsiniz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("kullanıcı adını boş geçemezsiniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("lütfen en az 3 karakter girişi yapın");
            RuleFor(x => x.Subject).MaximumLength(3).WithMessage("lütfen en az 3 karakter girişi yapın");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("lütfen kullanıcı adınız en az 3 karakter olmalı");

        }
    }
}
