using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Application.Interfaces.Services
{
    public interface IGenericService<CreateRequest, UpdateRequest, TDto, T>
        where CreateRequest : class
        where UpdateRequest : class
        where TDto : class
        where T : class
    {
        Task<List<TDto>> GetAllAsync();
        Task<TDto> GetByIdAsync(int id);
        Task<TDto> AddAsync(CreateRequest request);
        Task UpdateAsync(UpdateRequest request, int id);
        Task DeleteAsync(int id);
    }
}
