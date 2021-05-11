using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreAWSBlank.Models
{
    public class Descripcion
    {
        [DynamoDBProperty("colorojos")]
        public String Ojos { get; set; }
        [DynamoDBProperty("genero")]
        public String Genero { get; set; }

    }
}
