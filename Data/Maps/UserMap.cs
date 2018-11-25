using Delloite.TaskManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delloite.TaskManager.Data.Maps
{
    public sealed class UserMap : EntityTypeConfiguration<UserEntity>
    {
        public UserMap()
        {
            //Table User
            ToTable("User");
            HasKey(x => x.Id);

            //Id column
            Property(x => x.Id)
            .HasColumnName("UserId")
            .HasColumnType("Int");

            //Name column
            Property(x => x.UserName)
             .HasColumnName("UserName")
             .HasMaxLength(250)
             .HasColumnType("Varchar");

            //Email column
            Property(x => x.Email)
                .HasColumnName("Email")
                .HasMaxLength(250)
                .HasColumnType("Varchar");

            //Role Column
            Property(x => x.Role)
              .HasColumnName("Role")
              .HasMaxLength(50)
              .HasColumnType("Varchar");

            //Password Column
            Property(x => x.Password)
              .HasColumnName("Password")
              .HasMaxLength(50)
              .HasColumnType("Varchar");

            //IsAcitive Column
            Property(x => x.IsActive)
             .HasColumnName("IsActive")
             .HasColumnType("Bit");

        }
    }
}