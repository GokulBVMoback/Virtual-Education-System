using DAL.Entities;
using DAL.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Data.Entity.Migrations.Model.UpdateDatabaseOperation;

namespace DAL.MasterEntity
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=Tutoring")
        {
            //this.Configuration.LazyLoadingEnabled = false;
            //Database.SetInitializer<MyDbContext>(null);
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyDbContext, Configuration>());
            //Database.SetInitializer(new Configuration());
            //Database.SetInitializer<MyDbContext>(new CreateDatabaseIfNotExists<MyDbContext>());
        }

        #region [My Entities]

        public DbSet<tbl_users> tbl_users { get; set; }

        public DbSet<tbl_school> tbl_school { get; set; }

        public DbSet<tbl_class> tbl_class { get; set; }

        public DbSet<UserDisplay> UserDisplay { get; set; }

        public DbSet<tbl_student> tbl_students { get; set; }

        public DbSet<SubjectView> subjectView { get; set; }

        public DbSet<CourseView> CourseView { get; set; }
        public DbSet<Timetableview> Timetableview { get; set; }

        public DbSet<TeacherViewForStudent> teacherViewForIndividualStudents { get; set; }
        public DbSet<IndividualStudent> individualStudents { get; set; }

        public DbSet<PurchaseCouseView> purchaseCouseViews { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

    }
}
