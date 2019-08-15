using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            // base.Dispose(disposing);
        }
        // GET: Customers
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            //var customers = GetCustomers();
            /*                new List<Customer>
                        {
                            new Customer { Id = 1, Name = "John Smith" },
                            new Customer { Id = 2, Name = "Mary Williams" },
                        };
            */
            var viewModel = new CustomerViewModel
            {
                Customers = customers
            };

            return View(viewModel);
        }

        [Route("Customers/Index/{postId}")]
        public ActionResult ShowSingle(int postId)
        {
            var customers = _context.Customers.SingleOrDefault(x => x.Id == postId);

            if (customers == null)
                return HttpNotFound();

            var viewModel = new NewCustomerViewModel()
            {
                Customer = customers,
                MembershipType = _context.MembershipTypes.SingleOrDefault(m => m.Id == customers.MemberShipTypeId)
            };

            return View(viewModel);

        }


    }

}

