using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Delloite.TaskManager.Data.Entities;

namespace Delloite.TaskManager.Data.Maps
{
    public sealed class TaskMap : EntityTypeConfiguration<TaskEntity>
    {
        public TaskMap()
        {
            //Table
            ToTable("Task");         

            //Primary Key
            HasKey(x => x.Id);

            //Task Id
            Property(x => x.Id)
             .HasColumnName("TaskId")
             .HasColumnType("Int");

            //Usuar Id
            Property(x => x.UserId)
               .HasColumnName("UserId")
               .HasColumnType("Int");

                //Usuar Id
            Property(x => x.OwnerId)
               .HasColumnName("OwnerId")
               .HasColumnType("Int");


            //Usuar Id
            Property(x => x.UserUpdateId)
               .HasColumnName("UserUpdateId")
               .HasColumnType("Int");

            //Ttile Column
            Property(x => x.Title)
                .HasColumnName("Title")
                .HasMaxLength(100)
                .HasColumnType("Varchar");

            // Description Column
            Property(x => x.Description)
                .HasColumnName("Description")
                .HasMaxLength(800)
                .HasColumnType("Varchar");

            // Status Column
            Property(x => x.Status)
                .HasColumnName("Status")
                .HasMaxLength(30)
                .HasColumnType("Varchar");

            // Status Column
            Property(x => x.Priority)
                .HasColumnName("Priority")
                .HasMaxLength(30)
                .HasColumnType("Varchar");

            // CreationDate  Column
            Property(x => x.CreationDate)
                .HasColumnName("CreationDate")               
                .HasColumnType("DateTime");

            // CreationDate  Column
            Property(x => x.LastModifiedDate)
                .HasColumnName("LastModifiedDate")
                .HasColumnType("DateTime");

            //Creation of the relationship with the user as Creator.
            HasRequired(x => x.User)
            .WithMany(x => x.Tasks)
            .HasForeignKey(x => x.UserId);

            //Creation of the relationship with the user as Owner.
            HasRequired(x => x.User)
            .WithMany(x => x.Tasks)
            .HasForeignKey(x => x.OwnerId);

            //Creation of the relationship with the user as Usuer Upaged.
            HasRequired(x => x.User)
            .WithMany(x => x.Tasks)
            .HasForeignKey(x => x.UserUpdateId);
        }
    }
}





