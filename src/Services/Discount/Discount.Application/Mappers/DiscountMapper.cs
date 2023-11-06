using AutoMapper;

namespace Discount.Application.Mappers;

/// <summary>
/// Represents a mapper.
/// </summary>
public class DiscountMapper
{
    private static readonly Lazy<IMapper> LazyMapper = new(() =>
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.ShouldMapProperty = p => p.GetMethod!.IsPublic || p.GetMethod.IsAssembly;
            cfg.AddProfile<DiscountProfile>();
        });

        var mapper = config.CreateMapper();
        return mapper;
    });

    /// <summary>
    /// Gets mapper value.
    /// </summary>
    public static IMapper GetMapper => LazyMapper.Value;
}