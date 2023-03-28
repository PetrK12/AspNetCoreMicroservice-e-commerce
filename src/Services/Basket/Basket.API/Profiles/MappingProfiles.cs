using System;
using AutoMapper;
using Basket.API.Models;
using EventBus.Messages.Events;

namespace Basket.API.Profiles
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
            CreateMap<BasketCheckoutEvent, BasketCheckout>().ReverseMap();
        }
	}
}

