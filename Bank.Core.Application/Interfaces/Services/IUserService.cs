using Bank.Core.Application.Dto;
using Bank.Core.Domain.Entities;

namespace Bank.Core.Application.Interfaces.Services
{
    public interface IUserService : IGenericService<UserDto, User>
    {
    }
}
