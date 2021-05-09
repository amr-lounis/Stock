namespace Stock.Dataset.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("stock.permissions")]
    public partial class permission
    {
        [Column(TypeName = "uint")]
        public long ID { get; set; }

        [Required]
        [StringLength(25)]
        public string NAME { get; set; }

        [Required]
        [StringLength(25)]
        public string DESCRIPTION { get; set; }
    }
}
