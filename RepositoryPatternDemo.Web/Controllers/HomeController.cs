namespace RepositoryPatternDemo.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RepositoryPatternDemo.BLL.BusinessServices.ProductService;
    using RepositoryPatternDemo.Web.ViewModels;

    /// <summary>
    /// Provides members to land application to various page.
    /// </summary>
    public class HomeController : Controller
    {
        #region Member Variables

        private readonly IProductService productService;

        #endregion Member Variables

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Loads Product Category Relations.
        /// </summary>
        /// <returns>Index view</returns>
        public IActionResult Index()
        {
            var productCategoryRelationViewModel = new ProductCategoryRelationViewModel();

            productCategoryRelationViewModel.ProductCategoryRelations = productService.GetProductCategoryRelations();

            return View(productCategoryRelationViewModel);
        }

        #endregion Public Methods
    }
}
