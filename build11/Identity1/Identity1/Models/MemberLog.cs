//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Identity1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MemberLog
    {
        public int Id { get; set; }
        public int ActivityId { get; set; }
        public short Duration { get; set; }
        public System.DateTime Date { get; set; }
        public string ProfileMembershipNo { get; set; }
        public int ProfileId { get; set; }
    
        public virtual Activity Activity { get; set; }
    }
}
