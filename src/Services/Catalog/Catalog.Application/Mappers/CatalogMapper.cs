using AutoMapper;

namespace Catalog.Application.Mappers;

/// <summary>
/// Represents a catalog mapper.
/// </summary>
public static class CatalogMapper
{
    private static readonly Lazy<IMapper> LazyMapper = new(() =>
	{
		var mapperConfiguration = new MapperConfiguration(configure =>
		{
			configure.ShouldMapProperty = p => p.GetMethod!.IsPublic || p.GetMethod.IsAssembly;
			configure.AddProfile<CatalogProfile>();
		});

		var mapper = mapperConfiguration.CreateMapper();
        
		return mapper;
	});

	/// <summary>
	/// Gets mapper value.
	/// </summary>
	public static IMapper GetMapper => LazyMapper.Value;
}