namespace BooksCA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TransDetail
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string transID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookID { get; set; }

        public decimal Discount { get; set; }

        public decimal Amount { get; set; }

        public virtual Book Book { get; set; }

        public virtual Tran Tran { get; set; }
    }
}
