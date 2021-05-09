namespace Stock.Dataset.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("stock.invoices")]
    public partial class invoice
    {
        [Column(TypeName = "uint")]
        public long ID { get; set; }

        [Column(TypeName = "uint")]
        public long ID_USERS { get; set; }

        [Column(TypeName = "uint")]
        public long ID_CUSTOMERS { get; set; }

        [Required]
        [StringLength(25)]
        public string DESCRIPTION { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DATE { get; set; }

        public int VALIDATION { get; set; }

        public double MONEY_WITHOUT_ADDEDD { get; set; }

        public double MONEY_TAX { get; set; }

        public double MONEY_STAMP { get; set; }

        public double MONEY_TOTAL { get; set; }

        public double MONEY_PAID { get; set; }

        public double MONEY_UNPAID { get; set; }
    }
}
