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
    
    public partial class Curriculum
    {
        public int id { get; set; }
        public string chap_name { get; set; }
        public string link { get; set; }
        public Nullable<int> id_course { get; set; }
    
        public virtual Course Course { get; set; }
    }
}
