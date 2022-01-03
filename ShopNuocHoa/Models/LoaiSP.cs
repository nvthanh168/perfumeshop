namespace ShopNuocHoa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiSP")]
    public partial class LoaiSP
    {
        [Key]
        [StringLength(5)]
        public string maLoai { get; set; }

        [StringLength(50)]
        public string tenLoai { get; set; }

        [Column(TypeName = "ntext")]
        public string ghiChu { get; set; }

        [Column(TypeName = "text")]
        public string Anh { get; set; }
    }
}
