using AutoMapper;
using Siparis.EntityLayer.Concrete;
using Siparis.Web.UI.Models.Register;

namespace Siparis.Web.UI.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterViewModel, AppUser>().ReverseMap();
        }
    }
}
