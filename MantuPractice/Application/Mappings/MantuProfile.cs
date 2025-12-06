using AutoMapper;
using MantuPractice.Domain.Models;

namespace MantuPractice.Application.Mappings
{
    public class MantuProfile : Profile
    {
        public MantuProfile()
        {
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<AuditLog, AuditLogDTO>().ReverseMap();
            CreateMap<Brand, BrandDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Courier, CourierDTO>().ReverseMap();
            CreateMap<Inventory, InventoryDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            CreateMap<Payment, PaymentDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<ProductImage, ProductImageDTO>().ReverseMap();
            CreateMap<ProductVariant, ProductVariantDTO>().ReverseMap();
            CreateMap<Review, ReviewDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<Size, SizeDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Warehouse, WarehouseDTO>().ReverseMap();
        }
    }
}
