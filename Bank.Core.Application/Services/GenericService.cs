using AutoMapper;
using Bank.Core.Application.Interfaces.Repositories;
using Bank.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Application.Services
{
    public class GenericService<CreateRequest, UpdateRequest, TDto, T> : IGenericService<CreateRequest, UpdateRequest, TDto, T>
        where CreateRequest : class
        where UpdateRequest : class
        where TDto : class
        where T : class
    {
        private readonly IGenericRepository<T> _repo;
        private readonly IMapper _mapper;
        public GenericService(IGenericRepository<T> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<TDto>> GetAllAsync()
        {
            var TList = await _repo.GetAllAsync();
            return _mapper.Map<List<TDto>>(TList);
        }

        public async Task<TDto> GetByIdAsync(int id)
        {
            T T = await _repo.GetByIdAsync(id);
            return _mapper.Map<TDto>(T);
        }

        public virtual async Task<TDto> AddAsync(CreateRequest request)
        {
            T T = _mapper.Map<T>(request);
            T = await _repo.AddAsync(T);
            return _mapper.Map<TDto>(T);
        }

        public virtual async Task UpdateAsync(UpdateRequest request, int id)
        {
            T T = _mapper.Map<T>(request);
            await _repo.UpdateAsync(T, id);
        }

        public virtual async Task DeleteAsync(int id)
        {
            T T = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(T);
        }
    }
}
