using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using cars.Controllers.Resources;
using cars.Models;
using cars.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cars.Controllers
{
    [Route("api/[controller]")]
    public class MakesController : Controller
    {
        private readonly CarsDbContext context;
        private readonly IMapper mapper;

        public MakesController(CarsDbContext context, IMapper mapper)
        {
            if (context == null) {
                throw new ArgumentNullException(nameof(context));
            }
            if (mapper == null) {
                throw new ArgumentNullException(nameof(mapper));
            }

            this.context = context;
            this.mapper = mapper;

        }

        [HttpGet]
        public async Task<IEnumerable<MakeResource>> CarMakes()
        {
            var makes = await context.Makes.Include(m => m.Models).ToArrayAsync();
            var result = mapper.Map<IEnumerable<Make>, IEnumerable<MakeResource>>(makes);

            return result;
        }
    }
}