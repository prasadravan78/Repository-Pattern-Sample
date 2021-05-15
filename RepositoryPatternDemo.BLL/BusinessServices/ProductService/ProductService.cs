namespace RepositoryPatternDemo.BLL.BusinessServices.ProductService
{    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Dm = Model.Models;
    using RepositoryPatternDemo.DAL.Repositories.ProductRepository;
    using RepositoryPatternDemo.DAL.UnitOfWork;    

    /// <summary>
    ///  Provides members to manage Product entity.
    /// </summary>
    public class ProductService : IProductService
    {
        #region Member Variables

        private bool isDisposed = false;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IProductRepository productRepository;

        #endregion Member Variables

        #region Constructors

        /// <summary>
        /// Initializes service with dependencies.
        /// </summary>
        /// /// <param name="unitOfWork">Unit of work</param>
        /// <param name="productRepository">Product repository</param>
        public ProductService(IMapper mapper,
                              IUnitOfWork unitOfWork,
                              IProductRepository productRepository)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.productRepository = productRepository;
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Gets Products.
        /// </summary>
        /// <returns>List of Product</returns>
        public List<Dm.Product> GetProducts()
        {
            var products = new List<Dm.Product>();

            var originalProducts = productRepository.GetQueryableProducts(false).ToList();
            mapper.Map(originalProducts, products);

            return products;
        }

        /// <summary>
        /// Gets Product by Id.
        /// </summary>
        /// <param name="productId">Product id</param>
        /// <returns>Product by Id</returns>
        public Dm.Product GetProductById(int productId)
        {
            var product = new Dm.Product();

            var originalProduct = productRepository.GetById(productId);

            if (product != null)
            {
                mapper.Map(product, originalProduct);
            }

            return product;
        }

        #endregion Public Methods

        #region Private Methods

        #endregion Private Methods

        #region IDisposable Support

        /// <summary>
        /// Disposes the instance of UnitOfWork.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    //dispose managed state (managed objects).
                    if (unitOfWork != null)
                        unitOfWork.Dispose();
                }

                // free unmanaged resources (unmanaged objects) and override a finalizer below.
                // set large fields to null.

                isDisposed = true;
            }
        }

        /// <summary>
        /// Disposes current instance of the service.
        /// This code added to correctly implement the disposable pattern.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Support
    }
}
