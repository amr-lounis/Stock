namespace Stock.Dataset.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;

    [Table("stock.productsolds")]
    public partial class productsold
    {
        [Column(TypeName = "uint")]
        public long ID { get; set; }

        [Column(TypeName = "uint")]
        public long? ID_PRODUCT { get; set; }

        [Column(TypeName = "uint")]
        public long? ID_INVOICE { get; set; }

        [StringLength(25)]
        public string NAME { get; set; }

        [StringLength(255)]
        public string DESCRIPTION { get; set; }

        public double? MONEY_ONE { get; set; }

        public double? QUANTITY { get; set; }

        public double? TAX_PERCE { get; set; }

        public double? STAMP { get; set; }

        public double? MONEY_PAID { get; set; }
    }
}
