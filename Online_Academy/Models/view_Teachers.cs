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
    using System.Collections.Generic;
    
    public partial class view_Teachers
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string avatar { get; set; }
        public Nullable<System.DateTime> date_join { get; set; }
        public string major { get; set; }
        public Nullable<bool> state { get; set; }
        public Nullable<System.DateTime> birthday { get; set; }
        public string gender { get; set; }
        public Nullable<int> role { get; set; }
        public string description { get; set; }
        public Nullable<int> num_students { get; set; }
        public Nullable<int> num_cources { get; set; }
    }
}
