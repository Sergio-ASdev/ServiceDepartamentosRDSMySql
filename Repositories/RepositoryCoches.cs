
using ServiceDepartamentosRDSMySql.Data;
using ServiceDepartamentosRDSMySql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceDepartamentosRDSMySql.Repositories
{
    public class RepositoryCoches
    {
        CochesContext context;

        public RepositoryCoches(CochesContext context)
        {
            this.context = context;
        }

        internal List<Coche> GetCoches()
        {
            return this.context.Coches.ToList();
        }

        internal Coche FindCoche(int id)
        {
            return this.context.Coches.SingleOrDefault(x => x.idcoche == id);
        }
    }
}
