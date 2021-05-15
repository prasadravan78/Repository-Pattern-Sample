namespace RepositoryPatternDemo.BLL.Mappings
{
    using AutoMapper;
    using Dm = Model.Models;
    using RepositoryPatternDemo.Entity.Entities;      

    /// <summary>
    /// Provides mapping between domain/data transfer object and database entities.
    /// </summary>
    public class DomainDataModelMappingProfile : Profile
    {
        /// <summary>
        /// Gets mapping profile name.
        /// </summary>
        public override string ProfileName
        {
            get { return "DomainDataModelMapping"; }
        }

        /// <summary>
        /// Provides mapping between domain/data transfer object and database entities.
        /// </summary>
        public DomainDataModelMappingProfile()
        {
            CreateMap<Dm.BaseEntity, BaseEntity>();

            CreateMap<BaseEntity, Dm.BaseEntity>();
           
            CreateMap<Dm.Product, Product>().IncludeBase<Dm.BaseEntity, BaseEntity>();

            CreateMap<Product, Dm.Product>().IncludeBase<BaseEntity, Dm.BaseEntity>();
        }
    }
}
