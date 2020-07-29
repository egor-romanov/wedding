using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrimaryStorage;
using wedding.Models;
using wedding.Services;

namespace wedding.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SongsController : Controller
    {
        private readonly ILogger<SongsController> _logger;
        private readonly PrimaryStorageDb _primaryStorageDb;

        public SongsController(ILogger<SongsController> logger, PrimaryStorageDb primaryStorageDb)
        {
            _logger = logger;
            _primaryStorageDb = primaryStorageDb;
        }

        [HttpGet]
        public IEnumerable<Song> Get()
        {
            return _primaryStorageDb.Songs.Select(s => new Song
            {
                Name = s.Name,
                Id = s.Id,
                Ordered = s.Ordered
            });
        }

        [HttpPost]
        public async Task<ServiceResult> Add(
            [FromForm] string name,
            [FromForm] string ordered)
        {
            await _primaryStorageDb.Songs.AddAsync(new PrimaryStorage.Entities.Song { Name = name, Ordered = ordered });
            await _primaryStorageDb.SaveChangesAsync();

            return ServiceResult.Success;
        }
    }

}