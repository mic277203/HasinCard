using FluentValidation;
using HasinCard.Core.Domain;
using HasinCard.Core.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace HasinCard.Core.Validator.SysUser
{
    public class SysUsersValidator : AbstractValidator<SysUsersRequestDto>
    {
        public SysUsersValidator()
        {
            RuleFor(x => x.Email)
             .NotEmpty().WithMessage("邮箱不能为空")
             .EmailAddress().WithMessage("邮箱格式不能不正确")
             .MaximumLength(50).WithMessage("邮箱长度不能超过50");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("密码不能为空")
                .MaximumLength(15).WithMessage("昵称长度不能超过15");

            RuleFor(x => x.Name)
             .NotEmpty().WithMessage("昵称不能为空")
             .MaximumLength(20).WithMessage("昵称长度不能超过20");

            RuleFor(x => x.TelNo)
                 .NotEmpty().WithMessage("手机号不能为空")
                 .MaximumLength(15).WithMessage("手机号长度不能超过15")
                 .Must(p=> RegexHelper.IsMatch(p, @"^1[34578]\d{9}$")).WithMessage("手机号码不正确");

            RuleFor(x => x.QQ)
                .NotEmpty().WithMessage("QQ不能为空")
                .MaximumLength(15).WithMessage("QQ长度不能超过15");
        }
    }
}
