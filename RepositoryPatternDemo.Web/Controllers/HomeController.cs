namespace RepositoryPatternDemo.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RepositoryPatternDemo.BLL.BusinessServices.ProductService;
    using RepositoryPatternDemo.Model.Models;

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

        public IActionResult Index()
        {
            var products = productService.GetProducts();

            return View(products);
        }

        public IActionResult GetProductById(int productId)
        {
            var product = new Product();

            if (productId > 0)
            {
                product = productService.GetProductById(productId);
            }

            return View(product);
        }

        #endregion Public Methods
    }
}
