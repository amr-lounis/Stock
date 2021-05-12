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
<<<<<<< HEAD
=======

        public virtual permission permission { get; set; }

        public virtual role role { get; set; }
>>>>>>> 56794b865720454a67a5f629147411f52097afcc
    }
}
