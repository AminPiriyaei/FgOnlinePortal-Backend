using System;
using System.Collections.Generic;
using System.Text;
//***
using System.ComponentModel.DataAnnotations;

namespace FgOnlinePortal.Core.DTOs
{
    public  class PaymentRegisterViewModel
    {
        [Display(Name = "نام وب سایت")]
        [Required(ErrorMessage = "لطفا نام سایت را مشخص کنید")]
        public string NameWebsite { get; set; }
        [Required(ErrorMessage = "لطفا تلفن را مشخص کنید")]
        [Display(Name = "تلفن پشتیبانی")]
        public int Tell { get; set; }
        [Display(Name = "شماره حساب")]
        [Required(ErrorMessage = "لطفا شماره حساب را مشخص کنید")]
        public int BankAccount { get; set; }
        [Display(Name = "آدرس وب سایت ")]
        [Required(ErrorMessage = "لطفاآدرس را مشخص کنید")]
        public string AddressWebsite { get; set; }
    }

    public enum PaymentRegisterResult
    {
        Success,
        AddressWebsiteExists
    }
}
