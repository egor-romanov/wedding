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
    public class InviteController : Controller
    {
        private readonly ILogger<InviteController> _logger;
        private readonly PrimaryStorageDb _primaryStorageDb;

        public InviteController(ILogger<InviteController> logger, PrimaryStorageDb primaryStorageDb)
        {
            _logger = logger;
            _primaryStorageDb = primaryStorageDb;
        }

        [HttpGet("{secret}")]
        public IEnumerable<Guest> Get(string secret)
        {
            return _primaryStorageDb.Guests.Where(g => g.Secret == secret).Select(g => new Guest
            {
                Name = g.Name,
                Id = g.Id,
                ImagePath = g.ImagePath,
                Accepted = g.Accepted,
                Comments = g.GuestComments.Select(c => c.Comment).ToList(),
            }).ToList();
        }

        [HttpPost("{secret}/accept")]
        public async Task<ServiceResult> Accept(string secret,
            [FromForm] bool accept)
        {
            if (_primaryStorageDb.Guests.Where(g => g.Secret == secret).Count() > 0)
            {
                var guests = _primaryStorageDb.Guests.Where(g => g.Secret == secret);

                foreach (var guest in guests)
                    guest.Accepted = accept;

                await _primaryStorageDb.SaveChangesAsync();
                return ServiceResult.Success;
            }
            return null;
        }
    }

}