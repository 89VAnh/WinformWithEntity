//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAO
{
    using System;
    using System.Collections.Generic;
    
    public partial class HDTaiQuan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HDTaiQuan()
        {
            this.CTHDTaiQuans = new HashSet<CTHDTaiQuan>();
        }
    
        public int Ma { get; set; }
        public Nullable<int> MaBan { get; set; }
        public string GiamGia { get; set; }
        public string MaNV { get; set; }
        public int TongTien { get; set; }
        public string MaKH { get; set; }
        public System.DateTime ThoiGianVao { get; set; }
        public Nullable<System.DateTime> ThoiGianRa { get; set; }
    
        public virtual Ban Ban { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHDTaiQuan> CTHDTaiQuans { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}
