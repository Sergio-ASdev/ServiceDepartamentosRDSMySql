using Microsoft.AspNetCore.Mvc;
using ServiceDepartamentosRDSMySql.Models;
using ServiceDepartamentosRDSMySql.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceDepartamentosRDSMySql.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class CochesController : ControllerBase
        {
            RepositoryCoches repo;

            public CochesController(RepositoryCoches repo)
            {
                this.repo = repo;
            }

            [HttpGet]
            public List<Coche> GetCoches()
            {
                return this.repo.GetCoches();
            }

            [HttpGet("{id}")]
            public Coche FindCoche(int id)
            {
                return this.repo.FindCoche(id);
            }
        }
}
