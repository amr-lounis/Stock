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

        public double? MONEY_ONE { get; set; }

        public double? QUANTITY { get; set; }

        public double? TAX_PERCE { get; set; }

        public double? STAMP { get; set; }

        //private double? _MONEY_PAID;
        //public double? MONEY_PAID
        //{
        //    get { _MONEY_PAID = (this.MONEY_ONE * this.QUANTITY) + TAX_VALUE + STAMP; return _MONEY_PAID; }
        //    set { _MONEY_PAID = value; }
        //}
        //private double? _TAX_VALUE;
        //public double? TAX_VALUE
        //{
        //    get { _TAX_VALUE = this.MONEY_ONE * this.TAX_PERCE / 100; return _TAX_VALUE;  }
        //    set { _MONEY_PAID = value; }
        //}

    }
}
