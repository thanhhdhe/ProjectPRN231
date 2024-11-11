using AutoMapper;
using OnlineShop.Application.Reviews.Command.CreateReview;
using OnlineShop.Application.Reviews.Command.UpdateReview;
using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Reviews.DTO
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<CreateReviewCommand, Review>();
            CreateMap<UpdateReviewCommand, Review>();
            CreateMap<Review, ReviewDTO>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FirstName + " " + src.Customer.LastName));
        }
    }
}
