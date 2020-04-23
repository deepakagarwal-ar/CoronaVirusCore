using AutoMapper;
using DeepakGallery.Data.Entities;
using DeepakGallery.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DeepakGallery.Data.Mapper
{
    public class DataMapperProfile : Profile
    {
        public DataMapperProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(dest => dest.OrderId, x => x.MapFrom(src => src.Id))
                .ForMember(dest=>dest.OrderItems, x=>x.MapFrom(src=>src.Items))
                .ReverseMap();
            CreateMap<OrderItem, OrderItemViewModel>().ReverseMap();
        }

    }
}
