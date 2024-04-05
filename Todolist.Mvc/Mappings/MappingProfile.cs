using AutoMapper;
using Todolist.Mvc.Models;

namespace Todolist.Mvc.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Todo, TodoDto>().ReverseMap();
    }
}