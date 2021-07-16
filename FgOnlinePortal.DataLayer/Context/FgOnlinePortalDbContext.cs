using FgOnlinePortal.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FgOnlinePortal.DataLayer.Context
{
    public class FgOnlinePortalDbContext:DbContext
    {

        #region constructor

        public FgOnlinePortalDbContext(DbContextOptions<FgOnlinePortalDbContext> options) : base(options)
        {
        }

        #endregion


        #region Db Sets
        DbSet<Category> Categories { get; set; }
        DbSet<PaymentGateway> PaymentGateways { get; set; }
        DbSet<CategoryToPayment> CategoryToPayments { get; set; }
        #endregion

        #region disable cascading delete in database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascades = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascades)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }
        #endregion

    }
}
