using FgOnlinePortal.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FgOnlinePortal.DataLayer.Entities
{
    public class CategoryToPayment:BaseEntity
    {
        #region property
        public long CategoryId { get; set; }
        public long PaymentGatewayId { get; set; }
        #endregion
        #region Relation
        public PaymentGateway PaymentGateway { get; set; }
        public Category Category { get; set; }
        #endregion
    }
}
