using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace theGoodPushService.DataModels
{
    public class GoodPushContext : DbContext
    {
        public GoodPushContext()
            : base("name=DefaultConnection")
        {

        }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<DeviceSetting> DeviceSettings { get; set; }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Database.SetInitializer(new MyDbContextInitializer());

        //    base.OnModelCreating(modelBuilder);
        //}

        //public class MyDbContextInitializer : DropCreateDatabaseIfModelChanges<AlertContext>
        //{
        //    protected override void Seed(AlertContext dbContext)
        //    {
        //        // seed data

        //        base.Seed(dbContext);
        //    }
        //}
    }
  
}