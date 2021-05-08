namespace Stock.Dataset.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("stock.products")]
    public partial class product
    {
        [Column(TypeName = "uint")]
        public long ID { get; set; }

        [Column(TypeName = "uint")]
        public long? ID_CATEGORY { get; set; }

        [Column(TypeName = "uint")]
        public long? ID_UNITE { get; set; }

        [StringLength(25)]
        public string NAME { get; set; }

        [StringLength(25)]
        public string CODE { get; set; }

        public double? IMPORTANCE { get; set; }

        public double? QUANTITY { get; set; }

        public double? QUANTITY_MIN { get; set; }

        public double? TAX_PERCE { get; set; }

        public double? MONEY_PURCHASE { get; set; }

        public double? MONEY_SELLING_MIN { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? DATE_PRODUCTION { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? DATE_PURCHASE { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? DATE_EXPIRATION { get; set; }

        [StringLength(255)]
        public string DESCRIPTION { get; set; }
    }
}
