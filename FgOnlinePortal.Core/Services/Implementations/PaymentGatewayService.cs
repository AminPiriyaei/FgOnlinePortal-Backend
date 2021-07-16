using FgOnlinePortal.Core.DTOs;
using FgOnlinePortal.Core.Services.Interfaces;
using FgOnlinePortal.DataLayer.Context;
using FgOnlinePortal.DataLayer.Entities;
using FgOnlinePortal.DataLayer.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FgOnlinePortal.Core.Services.Implementations
{
    public class PaymentGatewayService : IPaymentGatewayService
    {
        #region property
        private readonly IGenericRepository<PaymentGateway> paymentRepository;
        private readonly IGenericRepository<Category> categoryRepository;
        private readonly FgOnlinePortalDbContext context;
        #endregion
        #region Counstractor

        public PaymentGatewayService(IGenericRepository<PaymentGateway> paymenteRpository ,IGenericRepository<Category> categoryRepository,FgOnlinePortalDbContext context)
        {
            this.paymentRepository = paymenteRpository;        
            this.categoryRepository = categoryRepository;
            this.context = context;
        }
        #endregion


        public async Task<List<PaymentGateway>> GetAllPaymentGateways()
        {
            return await paymentRepository.GetEntitiesQuery().ToListAsync();
        }
        public bool IsUserExistsByAddressWebsite(string addressWebsite)
        {
            return paymentRepository.GetEntitiesQuery().Any(a => a.AddressWebsite == addressWebsite.ToLower().Trim());
        }

        public async Task<PaymentGateway> GetPaymentByAddressWebsite(string addressWebsite)
        {
            return await paymentRepository.GetEntitiesQuery().SingleOrDefaultAsync(a => a.AddressWebsite == addressWebsite.ToLower().Trim());
        }

        public async Task<PaymentLoginResult> PaymentLoginUser(PaymentLoginViewModel paymentlogin)
        {
            var user = await paymentRepository.GetEntitiesQuery()
                .SingleOrDefaultAsync(s => s.AddressWebsite == paymentlogin.AddressWebsite.ToLower().Trim());
            if (user == null) return PaymentLoginResult.IncorrectData;
            return PaymentLoginResult.Success;
        }

        public async Task<PaymentRegisterResult> PaymentRegisterUser(PaymentRegisterViewModel payment)
        {
            if (IsUserExistsByAddressWebsite(payment.AddressWebsite))
                return PaymentRegisterResult.AddressWebsiteExists;
            var payments = new PaymentGateway
            {
                AddressWebsite = payment.AddressWebsite,
                Tell = payment.Tell,
                NameWebsite = payment.NameWebsite,
                BankAccount = payment.BankAccount
            };
            await paymentRepository.AddEntity(payments);
            await paymentRepository.SaveChanges();
            return PaymentRegisterResult.Success;
        }

        #region Categories
        public async Task<List<Category>> GetAllActivePaymentsCategories()
        {
            return await categoryRepository.GetEntitiesQuery().Where(s=>!s.IsDelete).ToListAsync();
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            paymentRepository?.Dispose();
        }

       
        #endregion


    }
}
