using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FgOnlinePortal.Core.DTOs
{
    public class PaymentLoginViewModel
    {

        [Display(Name = "آدرس وب سایت ")]
        [Required(ErrorMessage = "لطفاآدرس وب سایت را مشخص کنید")]
        [MaxLength(100)]
        public string AddressWebsite { get; set; }

    }

    public enum PaymentLoginResult
    {
        Success,
        IncorrectData,
        NotActivated

    }
}
