using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
//***
using FgOnlinePortal.DataLayer.Common;

namespace FgOnlinePortal.DataLayer.Entities
{
    public class Category : BaseEntity
    {
        #region property
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا نوع سایت را مشخص کنید")]
        public string Title { get; set; }
        [Display(Name = "توضیحات")]
        [MaxLength(300, ErrorMessage = "تعداد کاراکتر شما بیش از حد مجاز است")]
        public string Description { get; set; }
        #endregion
        #region relation
        public ICollection<CategoryToPayment> categoryToPayments{ get; set; }
        #endregion
    }
}
