namespace Stock.Dataset.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("stock.sold_products")]
    public partial class sold_products
    {
        [Column(TypeName = "uint")]
        public long ID { get; set; }

        [Column(TypeName = "uint")]
        public long ID_PRODUCT { get; set; }

        [Column(TypeName = "uint")]
        public long ID_INVOICE { get; set; }

        public double MONEY_ONE { get; set; }

        public double QUANTITY { get; set; }

        public double TAX_PERCE { get; set; }

        public double STAMP { get; set; }
    }
}
