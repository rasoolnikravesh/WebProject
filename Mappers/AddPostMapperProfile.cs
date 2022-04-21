using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappers
{
    public class AddPostMapperProfile : AutoMapper.Profile
    {
        public AddPostMapperProfile()
        {
            CreateMap<ViewModels.MangeBlog.AddPostViewModel, Models.Post>()
                .ForMember(p => p.Title, t => t.MapFrom(z => z.Title))
                .ForMember(p => p.Summary, t => t.MapFrom(z => z.Summary))
                .ForMember(p => p.Content, t => t.MapFrom(z => z.Content))
                .ReverseMap();
        }
    }
}
