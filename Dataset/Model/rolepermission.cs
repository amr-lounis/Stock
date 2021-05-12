namespace Stock.Dataset.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("stock.rolepermissions")]
    public partial class rolepermission
    {
        [Column(TypeName = "uint")]
        public long ID { get; set; }

        [Column(TypeName = "uint")]
        public long? ID_ROLE { get; set; }

        [Column(TypeName = "uint")]
        public long? ID_PERMISSION { get; set; }

        public virtual permission permission { get; set; }

        public virtual role role { get; set; }
    }
}
