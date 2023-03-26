using AutoMapper;
using Library.API.Models;
using Library.Domain.Entities;
using System;

namespace Library.API.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookResponse>();
    }
}
