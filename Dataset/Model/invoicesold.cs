namespace Stock.Dataset.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;

    [Table("stock.invoicesolds")]
    public partial class invoicesold
    {
        [Column(TypeName = "uint")]
        public long ID { get; set; }

        [Column(TypeName = "uint")]
        public long? ID_USERS { get; set; }

        [Column(TypeName = "uint")]
        public long? ID_CUSTOMERS { get; set; }

        [StringLength(25)]
        public string DESCRIPTION { get; set; }

        [Column(TypeName = "uint")]
        public long? VALIDATION { get; set; }

        [StringLength(25)]
        public string DATE { get; set; }

        public double? MONEY_WITHOUT_ADDEDD { get; set; }

        public double? MONEY_TAX { get; set; }

        public double? MONEY_STAMP { get; set; }

        public double? MONEY_TOTAL { get; set; }

        public double? MONEY_PAID { get; set; }

        public double? MONEY_UNPAID { get; set; }
    }
}
