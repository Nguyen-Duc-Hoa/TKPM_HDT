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
    
    public partial class sp_Purchase_Result
    {
        public int id { get; set; }
        public string name { get; set; }
        public string short_description { get; set; }
        public string thumbnail { get; set; }
        public int id_user { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<double> price { get; set; }
    }
}
