using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceDepartamentosRDSMySql.Models
{
    [Table("coches")]
    public class Coche
    {
        [Key]
        [Column("idcoche")]
        public int idcoche { get; set; }

        [Column("marca")]
        public String marca { get; set; }

        [Column("modelo")]
        public String modelo { get; set; }

        [Column("conductor")]
        public String conductor { get; set; }

        [Column("imagen")]
        public String imagen { get; set; }
    }
}
