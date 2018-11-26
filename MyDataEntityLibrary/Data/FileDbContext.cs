using MyDataEntityLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataEntityLibrary.Data
{
    //[DbConfigurationType(typeof(MyConfiguration))]
    public class FileDbContext: DbContext
    {
        public FileDbContext()
            :base("MyFile") // Web.config connectionStrings name
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<FileDbContext>());
        }

        public DbSet<FileModel> Files { get; set; }
    }

    public class MyConfiguration : DbConfiguration
    {
        public MyConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
            SetDefaultConnectionFactory(new LocalDbConnectionFactory("mssqllocaldb"));
        }
    }

}
