using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappers
{
    public class AddPostMapperProfile : AutoMapper.Profile
    {

        public AddPostMapperProfile(Data.IUnitOfWork unitOfWork)
        {
            CreateMap<ViewModels.MangeBlog.AddPostViewModel, Models.Post>()
                .ForMember(p => p.Title, t => t.MapFrom(z => z.Title))
                .ForMember(p => p.Summary, t => t.MapFrom(z => z.Summary))
                .ForMember(p => p.Content, t => t.MapFrom(z => z.Content))
                .ForMember(p => p.CategoryId, t => t.MapFrom(z => categoryid(z.CategoryName)))
                .ReverseMap();
            UnitOfWork = unitOfWork;
        }


        public IUnitOfWork UnitOfWork { get; }

        private Guid categoryid(string category)
        {
            var cat = UnitOfWork.CategoryRepository.GetByName(category);
            return cat.Id;
        }
    }
}
