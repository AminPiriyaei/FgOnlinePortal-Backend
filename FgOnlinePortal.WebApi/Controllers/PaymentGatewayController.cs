using FgOnlinePortal.Core.DTOs;
using FgOnlinePortal.Core.Services.Interfaces;
using FgOnlinePortal.Core.Utilities.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FgOnlinePortal.WebApi.Controllers
{
    public class PaymentGatewayController : SiteBaseController
    {


        #region Field
        private readonly IPaymentGatewayService paymentGatewayService;
        #endregion
        #region Counstractor
        public PaymentGatewayController(IPaymentGatewayService paymentGatewayService)
        {
           this.paymentGatewayService = paymentGatewayService;
        }
        #endregion

        #region paymentregister
        [HttpPost("paymentregister")]
        public async Task<IActionResult> PaymentRegister([FromBody] PaymentRegisterViewModel payment)
        {
            if (ModelState.IsValid)
            { 
                var pay = await paymentGatewayService.PaymentRegisterUser(payment);
                switch (pay)
                {
                    case PaymentRegisterResult.AddressWebsiteExists:

                        return JsonResponseStatus.Error(new { info = "AddressWebsiteExists" });
                }           
            }
            return JsonResponseStatus.Success();
        }
        #endregion

        #region paymentlogin

        [HttpPost("paymentlogin")]
        public async Task<IActionResult> PaymentLogin([FromBody] PaymentLoginViewModel paymentLogin)
        {
            if (ModelState.IsValid)
            {
                var res = await paymentGatewayService.PaymentLoginUser(paymentLogin);

                switch (res)
                {
                    case PaymentLoginResult.IncorrectData:
                        return JsonResponseStatus.Error(new { message = "آدر س وارد شده تکراری است  " });                
                }
            }
            return JsonResponseStatus.Success();
        }
        #endregion

        #region getpaymentcategories

        [HttpGet("payment-active-categories")]
        public async Task<IActionResult> GetPaymentsCategories()
        {

            return JsonResponseStatus.Success(await paymentGatewayService.GetAllActivePaymentsCategories());
        }

        #endregion
    }
}
