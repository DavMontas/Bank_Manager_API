using AutoMapper;
using Bank.Core.Application.Dto;
using Bank.Core.Application.Request;
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

            CreateMap<BankAccount, CreateBankAccountRequest>()
                .ReverseMap()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<BankAccount, UpdateBankAccountRequest>()
                .ReverseMap();

            CreateMap<BankAccountDto, CreateBankAccountRequest>()
                .ReverseMap()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<BankAccountDto, UpdateBankAccountRequest>()
                .ReverseMap();

            #endregion

            #region 'Transaction'

            CreateMap<Transaction, TransactionDto>()
                 .ReverseMap();

            CreateMap<Transaction, CreateTransactionRequest>()
                .ReverseMap()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<Transaction, UpdateTransactionRequest>()
                .ReverseMap();

            CreateMap<TransactionDto, CreateTransactionRequest>()
                .ReverseMap()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<TransactionDto, UpdateTransactionRequest>()
                .ReverseMap();

            #endregion

            #endregion
        }
    }
}
