//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Process
    {
        public int id_student { get; set; }
        public int id_Course { get; set; }
        public Nullable<int> process1 { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual User User { get; set; }
    }
}
