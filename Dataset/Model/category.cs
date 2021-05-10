namespace Stock.Dataset.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("stock.categorys")]
    public partial class category
    {
        [Column(TypeName = "uint")]
        public long ID { get; set; }

        [Column(TypeName = "uint")]
        public long ID_CATEGORY { get; set; }

        [StringLength(25)]
        public string NAME { get; set; }

        [StringLength(250)]
        public string DESCRIPTION { get; set; }
    }
}
