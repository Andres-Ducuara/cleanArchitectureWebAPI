using AC.Domain.Enitites;
using AC.Domain.Interface;
using CA.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CA.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<User> CreateAsync(User user)
        {
            _appDbContext.Users.Add(user);
            await _appDbContext.SaveChangesAsync();
             
            return user;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _appDbContext.Users
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();  
        }

        public async Task<List<User>> GetAllAsync(string? filter = null)
        {
            IQueryable<User> Users = _appDbContext.Users;


            if (!string.IsNullOrEmpty(filter))
            {
                Users = Users.Where(u => u.Name.Contains(filter) || u.DNI.Contains(filter));
            }

            return await Users.ToListAsync(); 
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _appDbContext.Users.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);   
        }

        public async Task<int> UpdateAsync(int id, User user)
        {
            return await _appDbContext.Users
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, user.Id)
                    .SetProperty(m => m.Name, user.Name)
                    .SetProperty(m => m.DNI, user.DNI)
                );
        }
    }
}
