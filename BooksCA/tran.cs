namespace BooksCA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tran
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tran()
        {
            transdetails = new HashSet<Transdetail>();
        }

        [Key]
        public int transID { get; set; }

        public int UserID { get; set; }

        [Column(TypeName = "date")]
        public DateTime transDate { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transdetail> transdetails { get; set; }
    }
}
