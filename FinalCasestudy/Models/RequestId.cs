//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalCasestudy.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RequestId
    {
        public int RequestId1 { get; set; }
        public string PatientName { get; set; }
        public Nullable<int> DoctorId { get; set; }
    
        public virtual DoctorDetail DoctorDetail { get; set; }
    }
}
