using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Bookshelf.Core.Domain.Entities;
using Bookshelf.Infrastructure.Data.Entities;

namespace Bookshelf.Infrastructure.Data.Mapping
{

    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {

            //CreateMap<TestDto, Test>().ReverseMap();

            CreateMap<UserModel, User>()
                .ForMember(dest => dest.Loans,
                    opt => opt.MapFrom(src => src.Loans)).ReverseMap();

            CreateMap<AuthorModel, Author>()
            .ForMember(dest => dest.Books,
                opt => opt.MapFrom(src => src.Books)).ReverseMap();

            CreateMap<LoanModel, Loan>()
            .ForMember(dest => dest.Book,
                opt => opt.MapFrom(src => src.Book))
            .ForMember(dest => dest.Users,
                opt => opt.MapFrom(src => src.Users)).ReverseMap();

            CreateMap<BookModel, Book>()
            .ForMember(dest => dest.Author,
                opt =>
                    opt.MapFrom(src => src.Author))
            .ForMember(dest => dest.Loans,
                opt => opt.MapFrom(src => src.Loans)).ReverseMap();
        }
    }
}
