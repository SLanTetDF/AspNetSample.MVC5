using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AspNetSample.MVC5.Models
{
    public class MeetingMinutesDB : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MeetingMinutesDB() : base("name=MeetingMinutesDB")
        {
        }
        public System.Data.Entity.DbSet<AspNetSample.MVC5.Models.MeetingMinutesOverview> MeetingMinutesOverviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<MeetingMinutesModel>().ToTable("MinuteData");
            base.OnModelCreating(modelBuilder);
        }

      
}
}
