using AutoMapper;
using MantuPractice.Application.CartServiceContainer;
using MantuPractice.Application.GenericCrudService;
using MantuPractice.Domain.Models;
using MantuPractice.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace MantuPractice.Startup
{
    public static class DependenciesConfig
    {
        public static void AddDependencies(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddCorsServices();
            builder.Services.AddOpenAPIServices();
        }

        public static void AddMantuServices(this IServiceCollection services)
        {
            services.AddScoped<ICartService, CartService>();
           

            services.AddScoped(typeof(ICrudService<AddressDTO>), typeof(CrudService<Domain.Models.Address, AddressDTO>));
            services.AddScoped(typeof(ICrudService<AuditLogDTO>), typeof(CrudService<AuditLog, AuditLogDTO>));
            services.AddScoped(typeof(ICrudService<BrandDTO>), typeof(CrudService<Brand, BrandDTO>));
            services.AddScoped(typeof(ICrudService<CategoryDTO>), typeof(CrudService<Category, CategoryDTO>));
            services.AddScoped(typeof(ICrudService<CourierDTO>), typeof(CrudService<Courier, CourierDTO>));
            services.AddScoped(typeof(ICrudService<InventoryDTO>), typeof(CrudService<Inventory, InventoryDTO>));
            services.AddScoped(typeof(ICrudService<OrderDTO>), typeof(CrudService<Order, OrderDTO>));
            services.AddScoped(typeof(ICrudService<OrderItemDTO>), typeof(CrudService<OrderItem, OrderItemDTO>));
            services.AddScoped(typeof(ICrudService<PaymentDTO>), typeof(CrudService<Payment, PaymentDTO>));
            services.AddScoped(typeof(ICrudService<ProductDTO>), typeof(CrudService<Product, ProductDTO>));
            services.AddScoped(typeof(ICrudService<ProductImageDTO>), typeof(CrudService<ProductImage, ProductImageDTO>));
            services.AddScoped(typeof(ICrudService<ProductVariantDTO>), typeof(CrudService<ProductVariant, ProductVariantDTO>));
            services.AddScoped(typeof(ICrudService<ReviewDTO>), typeof(CrudService<Review, ReviewDTO>));
            services.AddScoped(typeof(ICrudService<RoleDTO>), typeof(CrudService<Role, RoleDTO>));
            services.AddScoped(typeof(ICrudService<SizeDTO>), typeof(CrudService<Size, SizeDTO>));
            services.AddScoped(typeof(ICrudService<UserDTO>), typeof(CrudService<User, UserDTO>));
            services.AddScoped(typeof(ICrudService<WarehouseDTO>), typeof(CrudService<Warehouse, WarehouseDTO>));

            services.AddScoped(typeof(ICrudRepository<>), typeof(CrudRepository<>));
        }

    }
}
