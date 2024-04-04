using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCStartApp.Models;
using MVCStartApp.Models.Db;
using System;
using System.Threading.Tasks;

namespace MVCStartApp.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly BlogContext _context;
        public RequestRepository(BlogContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task WriteRequest(Request request)
        {

            var entry = _context.Entry(request);
            if (entry.State == EntityState.Detached)
                await _context.Requests.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        [HttpGet]
        public async Task<Request[]> GetRequets()
        {
            return await _context.Requests.ToArrayAsync();
        }
    }
}
