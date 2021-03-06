using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreAWSBlank.Models
{
   [DynamoDBTable("personajes")]
    public class Personaje
    {
        [DynamoDBProperty("idpersonaje")]
        [DynamoDBHashKey]
        public int IdPersonaje { get; set; }
        [DynamoDBProperty("pelicula")]
        public String NombrePelicula { get; set; }
        [DynamoDBProperty("personaje")]
        public String Personaj { get; set; }
        [DynamoDBProperty("imagen")]
        public String Imagen { get; set; }
        [DynamoDBProperty("idserie")]
        public int IdSerie { get; set; }
        [DynamoDBProperty("descripcion")]
        public Descripcion Descripcion { get; set; }
    }
}
