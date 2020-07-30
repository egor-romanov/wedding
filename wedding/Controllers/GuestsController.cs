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
    public class GuestsController : Controller
    {
        private readonly ILogger<GuestsController> _logger;
        private readonly PrimaryStorageDb _primaryStorageDb;

        public GuestsController(ILogger<GuestsController> logger, PrimaryStorageDb primaryStorageDb)
        {
            _logger = logger;
            _primaryStorageDb = primaryStorageDb;
        }

        [HttpGet]
        public IEnumerable<Guest> Get()
        {
            return _primaryStorageDb.Guests.Select(g => new Guest
            {
                Name = g.Name,
                Id = g.Id,
                ImagePath = g.ImagePath,
                Accepted = g.Accepted,
                Comments = g.GuestComments.Select(c => c.Comment).ToList()
            });
        }

        [HttpGet("{id}")]
        public Guest Get(int id)
        {
            return _primaryStorageDb.Guests.Where(g => g.Id == id).Select(g => new Guest
            {
                Name = g.Name,
                Id = g.Id,
                ImagePath = g.ImagePath,
                Accepted = g.Accepted,
                Comments = g.GuestComments.Select(c => c.Comment).ToList(),
            }).SingleOrDefault();
        }

        [HttpPost]
        public async Task<ServiceResult> Add(
            [FromForm] string name,
            [FromForm] string imagePath,
            [FromForm] string secret)
        {
            await _primaryStorageDb.Guests.AddAsync(new PrimaryStorage.Entities.Guest
            {
                Name = name,
                Secret = secret,
                ImagePath = imagePath
            });
            await _primaryStorageDb.SaveChangesAsync();
            return ServiceResult.Success;
        }

        [HttpPost("{id}/comment")]
        public async Task<ServiceResult> AddComment(int id,
            [FromForm] string comment)
        {
            if (comment == null || comment.Length < 3 || _primaryStorageDb.Guests.Where(g => g.Id == id).Count() == 0)
                return null;

            await _primaryStorageDb.GuestComments.AddAsync(new PrimaryStorage.Entities.GuestComment { GuestId = id, Comment = comment });
            await _primaryStorageDb.SaveChangesAsync();
            return ServiceResult.Success;


        }

        [HttpPost("{id}/accept")]
        public async Task<ServiceResult> Accept(int id,
            [FromForm] bool accept)
        {
            if (_primaryStorageDb.Guests.Where(g => g.Id == id).Count() > 0)
            {
                _primaryStorageDb.Guests.Where(g => g.Id == id).First().Accepted = accept;
                await _primaryStorageDb.SaveChangesAsync();
                return ServiceResult.Success;
            }
            return null;
        }
    }

}
