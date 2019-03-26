namespace WebApiRestE2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class calorias
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string email { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime fecha { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(1)]
        public string tipocomida { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int codigoalimento { get; set; }

        public int cantidad { get; set; }

        //    public virtual alimentos alimentos { get; set; }

        //    public virtual usuario usuario { get; set; }
    }
}
