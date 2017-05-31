using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MeetingMinutesSystem.Models
{
    public class MeetingMinutesDB : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
        private const string myConnectString = "name=MeetingMinutesSystemDataBase";
    
            //RYAN: the connection string had better declare as a const string.
        public MeetingMinutesDB() : base(myConnectString)
        {
            
        }
        public System.Data.Entity.DbSet<MeetingMinutesSystem.Models.MinutesModel> MeetingMinutesData { get; set; }

        //RYAN: please explain the purpose of this override function.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

      
}
}
