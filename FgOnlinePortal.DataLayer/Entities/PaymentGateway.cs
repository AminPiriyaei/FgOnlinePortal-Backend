using FgOnlinePortal.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
//***

namespace FgOnlinePortal.DataLayer.Entities
{
    public class PaymentGateway : BaseEntity
    {
        #region property
        [Display(Name = "نام وب سایت")]
        [Required(ErrorMessage = "لطفا نام سایت را مشخص کنید")]
        public string NameWebsite { get; set; }
        [Required(ErrorMessage = "لطفا تلفن را مشخص کنید")]
        [Display(Name = "تلفن پشتیبانی")]
        public long Tell { get; set; }
        [Display(Name = "شماره حساب")]
        [Required(ErrorMessage = "لطفا شماره حساب را مشخص کنید")]
        public  long BankAccount { get; set; }
        [Display(Name = "آدرس وب سایت ")]
        [Required(ErrorMessage = "لطفاآدرس وب سایت را مشخص کنید")]
        [MaxLength(100)]
        public string AddressWebsite { get; set; }
        #endregion

        #region relation
        public ICollection<CategoryToPayment> categoryToPayments{ get; set; }
        #endregion 
    }
}
