using AutoMapper;
using Bank.Core.Application.Dto;
using Bank.Core.Domain.Entities;


namespace Bank.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region mappings

            #region 'BankAccount'

            CreateMap<BankAccount, BankAccountDto>()
                .ReverseMap();

            #endregion

            #region 'User'

            CreateMap<User, UserDto>()
               .ReverseMap();

            #endregion

            #endregion
        }
    }
}
