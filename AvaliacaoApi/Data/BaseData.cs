using AvaliacaoApi.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AvaliacaoApi.Data
{
    public class BaseData
    {
        internal ApiContext _ApiContext;
        public BaseData(ApiContext context, IConfiguration configuration)
        {

        }

        public BaseData(IConfiguration configuration)
        {
        }
        public void BeginTransaction()
        {

        }
    }
}
