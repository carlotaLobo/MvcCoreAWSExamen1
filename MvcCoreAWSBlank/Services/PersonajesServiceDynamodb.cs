using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.S3;
using Microsoft.Extensions.Configuration;
using MvcCoreAWSBlank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreAWSBlank.Services
{
   
    public class PersonajesServiceDynamodb
    {
        private DynamoDBContext context; 

        public PersonajesServiceDynamodb()
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient();
            this.context = new DynamoDBContext(client);
        }

        public async Task CreatePersonaje(Personaje p)
        {
            await this.context.SaveAsync<Personaje>(p);
        }

        public async Task<List<Personaje>> GetPersonajes()
        {
            var tabla = this.context.GetTargetTable<Personaje>();
            var scanoptions = new ScanOperationConfig();
            var result = tabla.Scan(scanoptions);
            List<Document> data = await result.GetNextSetAsync();
            IEnumerable<Personaje> personajes = this.context.FromDocuments<Personaje>(data);
            return personajes.ToList();
        }

        public async Task<Personaje> GetPersonaje(int idpersonaje)
        {
            return await this.context.LoadAsync<Personaje>(idpersonaje);
        }
    }
}
