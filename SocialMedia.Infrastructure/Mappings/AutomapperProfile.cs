﻿namespace SocialMedia.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile() {
            CreateMap<Post , PostDto>().ReverseMap();
        }
    }
}
