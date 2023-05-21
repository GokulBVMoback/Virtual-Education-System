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
        public DbSet<TeacherViewForStudent> teacherViewForIndividualStudents { get; set; }
        public DbSet<IndividualStudent> individualStudents { get; set; }
        public DbSet<PurchaseCouseView> purchaseCouseViews { get; set; }
        public DbSet<tbl_course> tbl_course { get; set; }
        public DbSet<tbl_timetable> tbl_timetable { get; set; }
        public DbSet<tbl_subject> tbl_subject { get; set; }
        public DbSet<tbl_class> tbl_class { get; set; }
        public DbSet<UserDisplay> UserDisplay { get; set; }
        public DbSet<tbl_student> tbl_student { get; set; }
        public DbSet<CourseView> courseView { get; set; }
        public DbSet<TeacherDisplay> teacherDisplay { get; set; }
        public DbSet<studentView>studentView { get; set; }
        public DbSet<SubjectView> subjectView { get; set; }
        public DbSet<TeacherCouseView> teacherCouseViews { get; set; }
        public DbSet<Timetableview> Timetableview { get; set; }
        public DbSet<tbl_course_branch> tbl_course_branch { get; set; }
        public DbSet<tbl_course_topic> tbl_course_topic { get; set; }
        public DbSet<ClassSubject> ClassSubject { get; set; }
        public DbSet<tbl_avail_course> tbl_avail_course { get; set; }
        public DbSet<tbl_teacher_availability> tbl_teacher_availability { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

    }
}
