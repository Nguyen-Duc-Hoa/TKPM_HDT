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
    
    public partial class Cart
    {
        public int id_course { get; set; }
        public int id_user { get; set; }
        public string name { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual User User { get; set; }
    }
}
