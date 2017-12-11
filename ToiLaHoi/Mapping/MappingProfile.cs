using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using StackExchange.Redis;
using ToiLaHoi.Controllers.Resources;
using ToiLaHoi.Model;

namespace ToiLaHoi.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {

            CreateMap<User, UserResources>();
            CreateMap<Product, ProductResources>()
                .ForMember(vr => vr.Categories, opt => opt.MapFrom(v => v.Categories));
            CreateMap<ShoppingCart, ShoppingCartResources>();
            CreateMap<Cart, CartResources>();
            CreateMap<Categories, CategoryResources>();
            CreateMap<Orders, OrderResources>();
            CreateMap<Product, SaveProductResources>();
            CreateMap<User, SaveUserResources>();
            CreateMap<ShoppingCart, SaveShoppingCartResources>()
                .ForMember(vr => vr.Carts, opt => opt.MapFrom(v => v.Carts.Select(Carts => new SaveCartResources { Id = Carts.Id, Quantity = Carts.Quantity, ProductId = Carts.ProductId })));

            







            
            CreateMap<SaveProductResources, Product>()
                .ForMember(v => v.Id, opt => opt.Ignore());
            CreateMap<SaveUserResources, User>()
                .ForMember(v => v.Id, opt => opt.Ignore());


            CreateMap<SaveShoppingCartResources, ShoppingCart>()
                .ForMember(v => v.Id, opt => opt.Ignore())
                .ForMember(v => v.Carts, opt => opt.Ignore())
                .AfterMap((vr, v) =>
                {
                    // Remove unselected Carts
                    var removedCarts = v.Carts.Where(f => !vr.Carts.Contains(new SaveCartResources { Id = f.Id , Quantity = f.Quantity,ProductId = f.ProductId})).ToList();
                    foreach (var f in removedCarts)
                        v.Carts.Remove(f);

//                    // Add new Carts
                    var addedFeatures = vr.Carts.Where(cart => !v.Carts.Any(f => f.Id == cart.Id)).Select(Carts => new Cart { Id = Carts.Id, Quantity = Carts.Quantity,ProductId = Carts.ProductId}).ToList();
                    foreach (var f in addedFeatures)
                        v.Carts.Add(f);
                });
        }
    }
}
