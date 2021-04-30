using MvcCoreAWSBlank.Data;
using MvcCoreAWSBlank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreAWSBlank.Repositories
{
    public class Repository
    {
        Context context;

        public Repository(Context context)
        {
            this.context = context;
        }

        public List<Coche> GetCoches()
        {
            return this.context.Coches.ToList();
        }


    }
}
