using Microsoft.EntityFrameworkCore;
using MVCStartApp.Models;
using MVCStartApp.Models.Db;
using System;
using System.Threading.Tasks;

namespace MVCStartApp.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogContext _context;
        public BlogRepository(BlogContext context)
        {
            _context = context;
            Console.WriteLine("ContextCreated");
        }

        public async Task AddUser(User user)
        {
            user.JoinDate = DateTime.Now;
            user.Id = Guid.NewGuid();

            // Добавление пользователя
            var entry = _context.Entry(user);
            if (entry.State == EntityState.Detached)
                await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User[]> GetUsers()
        {
            //await ClearUsers();
            return await _context.Users.ToArrayAsync();
        }
        public async Task ClearUsers()
        {
            var users = await _context.Users.ToArrayAsync();
            foreach (var user in users) 
            {
                _context.Remove(user);
            }
            _context.SaveChanges();
        }
    }
}
