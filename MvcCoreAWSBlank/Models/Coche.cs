using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreAWSBlank.Models
{
    [Table("coches")]
    public class Coche
    {
        [Key]
        [Column("idcoche")]
        public int IdCoche { get; set; }
        [Column("modelo")]
        public String Modelo { get; set; }
        [Column("marca")]
        public String Marca { get; set; }
        [Column("conductor")]
        public String Conductor { get; set; }
        [Column("imagen")]
        public String Imagen { get; set; }
    }
}
