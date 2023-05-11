using System;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Play.Catalog.Aplication.Features.Items.Dtos;
using Play.Catalog.Aplication.Features.Items.Queries.GetItemById;
using Play.Catalog.Aplication.Features.Items.Queries.GetItemsList;
using Play.Catalog.Aplication.Profiles;
using Play.Catalog.Persistence.Repositories;

namespace Play.Catalog.Aplication
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddTransient<ItemRepository>();
            services.AddTransient<IRequestHandler<GetItemsListQuery, IEnumerable<ItemDto>>, GetItemsListQueryHandler>();
            services.AddTransient<IRequestHandler<GetItemByIdQuery, ItemDto>, GetItemByIdQueryHandler>();
            services.AddMediatR(c=>c.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            return services;
        }
    }
}

