using myApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myApp.DataAccess.Mapping
{
    public class UserMappingMySql : EntityTypeConfiguration<User>
    {
        public UserMappingMySql()
        {
            ToTable("user");
            HasKey(x => x.UserId);
            Property(x => x.Name).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            Property(x => x.Account).HasColumnType("varchar").HasMaxLength(16).IsRequired();
            Property(x => x.Account).HasColumnType("varchar").HasMaxLength(1000).IsRequired();
        }
    }

    public class UserMappingSqlServer : EntityTypeConfiguration<User>
    {
        public UserMappingSqlServer()
        {
            ToTable("user");
            HasKey(x => x.UserId);
            Property(x => x.Name).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            Property(x => x.Account).HasColumnType("varchar").HasMaxLength(16).IsRequired();
            Property(x => x.Account).HasColumnType("varchar").HasMaxLength(1000).IsRequired();
        }
    }
}
