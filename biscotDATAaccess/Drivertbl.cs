//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace biscotDATAaccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Drivertbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Drivertbl()
        {
            this.Triptbls = new HashSet<Triptbl>();
        }
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long N_Code { get; set; }
        public string FatherName { get; set; }
        public Nullable<long> N_Id { get; set; }
        public string BirthdayDate { get; set; }
        public Nullable<long> PhoneNumber { get; set; }
        public string Address { get; set; }
        public Nullable<int> CarId { get; set; }
        public byte[] Pic { get; set; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
            set {; }
        }
        public virtual Cartbl Cartbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Triptbl> Triptbls { get; set; }
    }
}
