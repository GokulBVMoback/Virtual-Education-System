using DAL.Entities;
using DAL.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public DbSet<tbl_course> tbl_course { get; set; }
        public DbSet<tbl_course_topic> tbl_Course_Topics { get; set; }
        public DbSet<tbl_timetable> tbl_timetable { get; set; }
        public DbSet<tbl_subject> tbl_subject { get; set; }
        public DbSet<tbl_class> tbl_class { get; set; }
        public DbSet<tbl_student> tbl_student { get; set; }
        public DbSet<CourseView> courseView { get; set; }
        public DbSet<Timetableview> timetableview { get; set; }
        public DbSet<TeacherDisplay> teacherDisplay { get; set; }
        public DbSet<studentView>studentView { get; set; }
        public DbSet<SubjectView> subjectView { get; set; }
        public DbSet<TeacherCouseView> teacherCouseViews { get; set; }

        public DbSet<Timetableview> Timetableview { get; set; }
        public DbSet<tbl_course_branch> tbl_course_branch { get; set; }
        public DbSet<tbl_course_topic> tbl_course_topic { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

    }
}
