﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Online_Academy.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DB_A72902_TKPMEntities : DbContext
    {
        public DB_A72902_TKPMEntities()
            : base("name=DB_A72902_TKPMEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bookdetail> Bookdetails { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Curriculum> Curricula { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<Lecture> Lectures { get; set; }
        public virtual DbSet<Process> Processes { get; set; }
        public virtual DbSet<Rate> Rates { get; set; }
        public virtual DbSet<Reply> Replies { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Subcategory> Subcategories { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<view_allCourses> view_allCourses { get; set; }
        public virtual DbSet<view_allCurriculum> view_allCurriculum { get; set; }
        public virtual DbSet<view_allLectures> view_allLectures { get; set; }
        public virtual DbSet<view_allUsers> view_allUsers { get; set; }
        public virtual DbSet<view_Bookdetail> view_Bookdetail { get; set; }
        public virtual DbSet<view_categories> view_categories { get; set; }
        public virtual DbSet<view_Course_rate> view_Course_rate { get; set; }
        public virtual DbSet<view_History> view_History { get; set; }
        public virtual DbSet<view_Subcategories> view_Subcategories { get; set; }
        public virtual DbSet<view_Teachers> view_Teachers { get; set; }
    
        [DbFunction("DB_A72902_TKPMEntities", "func_Course")]
        public virtual IQueryable<func_Course_Result> func_Course(Nullable<int> idStudent)
        {
            var idStudentParameter = idStudent.HasValue ?
                new ObjectParameter("idStudent", idStudent) :
                new ObjectParameter("idStudent", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<func_Course_Result>("[DB_A72902_TKPMEntities].[func_Course](@idStudent)", idStudentParameter);
        }
    
        public virtual ObjectResult<getBookdetail_Result> getBookdetail(Nullable<int> id_student, Nullable<int> id_course)
        {
            var id_studentParameter = id_student.HasValue ?
                new ObjectParameter("id_student", id_student) :
                new ObjectParameter("id_student", typeof(int));
    
            var id_courseParameter = id_course.HasValue ?
                new ObjectParameter("id_course", id_course) :
                new ObjectParameter("id_course", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getBookdetail_Result>("getBookdetail", id_studentParameter, id_courseParameter);
        }
    
        public virtual ObjectResult<getCourseByState_Result> getCourseByState(Nullable<bool> state)
        {
            var stateParameter = state.HasValue ?
                new ObjectParameter("state", state) :
                new ObjectParameter("state", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getCourseByState_Result>("getCourseByState", stateParameter);
        }
    
        public virtual ObjectResult<getCourseByStateSave_Result> getCourseByStateSave(Nullable<int> id, Nullable<bool> statesave)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var statesaveParameter = statesave.HasValue ?
                new ObjectParameter("statesave", statesave) :
                new ObjectParameter("statesave", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getCourseByStateSave_Result>("getCourseByStateSave", idParameter, statesaveParameter);
        }
    
        public virtual ObjectResult<getCurriculumByCourse_Result> getCurriculumByCourse(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getCurriculumByCourse_Result>("getCurriculumByCourse", idParameter);
        }
    
        public virtual ObjectResult<getLectureByCurriculum_Result> getLectureByCurriculum(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getLectureByCurriculum_Result>("getLectureByCurriculum", idParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> getNumberofLectures(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("getNumberofLectures", idParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> getNumberofStudents(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("getNumberofStudents", idParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> getStudentByCourse(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("getStudentByCourse", idParameter);
        }
    
        public virtual ObjectResult<getTeacherById_Result> getTeacherById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getTeacherById_Result>("getTeacherById", idParameter);
        }
    
        public virtual ObjectResult<getTeacherByName_Result> getTeacherByName(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getTeacherByName_Result>("getTeacherByName", nameParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> getTotalCourse(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("getTotalCourse", idParameter);
        }
    
        public virtual ObjectResult<Nullable<double>> getTotalReveneuAllCourses(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<double>>("getTotalReveneuAllCourses", idParameter);
        }
    
        public virtual ObjectResult<Nullable<double>> getTotalReveneuCourse(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<double>>("getTotalReveneuCourse", idParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> getTotalStudentAllCourse(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("getTotalStudentAllCourse", idParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> getTotalStudentCourse(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("getTotalStudentCourse", idParameter);
        }
    
        public virtual int sp_add_favorite(Nullable<int> idStudent, Nullable<int> idCourse, Nullable<System.DateTime> date)
        {
            var idStudentParameter = idStudent.HasValue ?
                new ObjectParameter("idStudent", idStudent) :
                new ObjectParameter("idStudent", typeof(int));
    
            var idCourseParameter = idCourse.HasValue ?
                new ObjectParameter("idCourse", idCourse) :
                new ObjectParameter("idCourse", typeof(int));
    
            var dateParameter = date.HasValue ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_add_favorite", idStudentParameter, idCourseParameter, dateParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual ObjectResult<sp_Course_bought_Result> sp_Course_bought(Nullable<int> idUser)
        {
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Course_bought_Result>("sp_Course_bought", idUserParameter);
        }
    
        public virtual ObjectResult<sp_Couse_User_Result> sp_Couse_User(Nullable<int> idStudent)
        {
            var idStudentParameter = idStudent.HasValue ?
                new ObjectParameter("idStudent", idStudent) :
                new ObjectParameter("idStudent", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Couse_User_Result>("sp_Couse_User", idStudentParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_findAll_Cate_Result> sp_findAll_Cate()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_findAll_Cate_Result>("sp_findAll_Cate");
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_Purchase_Result> sp_Purchase()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Purchase_Result>("sp_Purchase");
        }
    
        public virtual int sp_remove_favorite(Nullable<int> idStudent, Nullable<int> idCourse)
        {
            var idStudentParameter = idStudent.HasValue ?
                new ObjectParameter("idStudent", idStudent) :
                new ObjectParameter("idStudent", typeof(int));
    
            var idCourseParameter = idCourse.HasValue ?
                new ObjectParameter("idCourse", idCourse) :
                new ObjectParameter("idCourse", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_remove_favorite", idStudentParameter, idCourseParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_SumLesson(Nullable<int> idCourse)
        {
            var idCourseParameter = idCourse.HasValue ?
                new ObjectParameter("idCourse", idCourse) :
                new ObjectParameter("idCourse", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_SumLesson", idCourseParameter);
        }
    
        public virtual ObjectResult<sp_teacherCourses_Result> sp_teacherCourses(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_teacherCourses_Result>("sp_teacherCourses", idParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_testBought(Nullable<int> idUser, Nullable<int> idCourse)
        {
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(int));
    
            var idCourseParameter = idCourse.HasValue ?
                new ObjectParameter("idCourse", idCourse) :
                new ObjectParameter("idCourse", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_testBought", idUserParameter, idCourseParameter);
        }
    
        public virtual int sp_UpdateProcess(Nullable<int> idUser, Nullable<int> idCourse, Nullable<int> process)
        {
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(int));
    
            var idCourseParameter = idCourse.HasValue ?
                new ObjectParameter("idCourse", idCourse) :
                new ObjectParameter("idCourse", typeof(int));
    
            var processParameter = process.HasValue ?
                new ObjectParameter("process", process) :
                new ObjectParameter("process", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_UpdateProcess", idUserParameter, idCourseParameter, processParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}
