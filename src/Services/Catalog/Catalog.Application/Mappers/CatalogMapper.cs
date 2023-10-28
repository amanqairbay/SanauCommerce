using AutoMapper;

namespace Catalog.Application.Mappers;

/// <summary>
/// Represents a catalog mapper.
/// </summary>
public static class CatalogMapper
{
    private static readonly Lazy<IMapper> LazyMapper = new(() =>
	{
		var configuration = new MapperConfiguration(cfg =>
		{
			cfg.ShouldMapProperty = p => p.GetMethod!.IsPublic || p.GetMethod.IsAssembly;
			cfg.AddProfile<CatalogProfile>();
		});

		var mapper = configuration.CreateMapper();
        
		return mapper;
	});

	/// <summary>
	/// Gets mapper value.
	/// </summary>
	public static IMapper GetMapper => LazyMapper.Value;
}