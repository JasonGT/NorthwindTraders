﻿using AutoMapper;
using Northwind.Application.Infrastructure.Mappings;
using Northwind.Domain.Entities;

namespace Northwind.Application.Customers.Queries.GetCustomersList
{
    public class CustomerLookupModel : IMapFrom<Customer>
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerLookupModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.CustomerId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.CompanyName));
        }
    }
}
