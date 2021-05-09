namespace Stock.Dataset.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("stock.roles_permissions")]
    public partial class roles_permissions
    {
        [Column(TypeName = "uint")]
        public long ID { get; set; }

        [Column(TypeName = "uint")]
        public long ID_ROLE { get; set; }

        [Column(TypeName = "uint")]
        public long ID_PERMISSION { get; set; }
    }
}
