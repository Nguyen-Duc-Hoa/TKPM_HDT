//------------------------------------------------------------------------------
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
    
    public partial class sp_teacherCourses_Result
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string short_description { get; set; }
        public string thumbnail { get; set; }
        public string preview { get; set; }
        public Nullable<int> id_teacher { get; set; }
        public Nullable<int> id_subcat { get; set; }
        public Nullable<bool> state { get; set; }
        public Nullable<int> price { get; set; }
        public Nullable<int> discount { get; set; }
        public Nullable<bool> statesave { get; set; }
    }
}
