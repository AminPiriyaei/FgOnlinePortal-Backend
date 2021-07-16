using FgOnlinePortal.Core.DTOs;
using FgOnlinePortal.Core.Services.Implementations;
using FgOnlinePortal.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FgOnlinePortal.Core.Services.Interfaces
{
    public interface IPaymentGatewayService:IDisposable
    {
        Task<List<PaymentGateway>> GetAllPaymentGateways();
        Task<PaymentRegisterResult> PaymentRegisterUser(PaymentRegisterViewModel payment);
        /// <summary>
        /// IsExistsAddressWebsite
        /// </summary>
        /// <param name="addressWebsite"></param>
        /// <returns></returns>
        bool IsUserExistsByAddressWebsite(string addressWebsite);
        Task<PaymentGateway> GetPaymentByAddressWebsite(string addressWebsite);
        Task<PaymentLoginResult> PaymentLoginUser(PaymentLoginViewModel paymentlogin);

        #region Categories
        Task<List<Category>> GetAllActivePaymentsCategories();
        #endregion

    }
}
