using AutoMapper;
using Model.InputDto.Dictionary;
using DM = Model.DBModel;

namespace Common
{
    public class DtoMapProfile : Profile
    {
        public DtoMapProfile()
        {
            CreateMap<DictionaryInput, DM.Dictionary>();
        }
    }
}
