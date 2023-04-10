using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Application.Interfaces.Services
{
    public interface IGenericService<TDto, T>
        where TDto : class
        where T : class
    {
        Task<List<TDto>> GetAllAsync();
        Task<TDto> GetByIdAsync(int id);
        Task<TDto> AddAsync(TDto dto);
        Task UpdateAsync(TDto dto, int id);
        Task DeleteAsync(int id);
    }
}
