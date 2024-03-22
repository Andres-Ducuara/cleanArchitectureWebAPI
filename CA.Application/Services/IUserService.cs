using AC.Domain.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Application.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync(string? filter = null);
        Task<User> GetByIdAsync(int id);
        Task<User> CreateAsync(User user);
        Task<int> UpdateAsync(int id, User user);
        Task<int> DeleteAsync(int id);
    }
}
