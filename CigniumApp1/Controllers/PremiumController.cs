using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cignium.Core.Entities;
using Microsoft.AspNetCore.Cors;
using Cignium.Infrastructure.Data;

namespace CigniumApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("permitir")]
    public class PremiumController : ControllerBase
    {

        // GET: api/Premium/
        [HttpGet("{sta}/{month}/{age}", Name = "GetSpecific")]
        public List<TablePremium> GetSpecific(string sta, string month, int age)
        {
            //This controller calls Cignium.Infrastructure, there is the data
            CatalogTablePremium catalog = new CatalogTablePremium();
            return catalog.FindByParameters(sta, month,age);
        }

      
    }
}
