using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" },
                new Customer { Id = 3, Name = "John Doe" }
            };
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomers();
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
            var customers = GetCustomers().SingleOrDefault(x => x.Id == postId);
            /*                new List<Customer>
                        {
                            new Customer { Id = 1, Name = "John Smith" },
                            new Customer { Id = 2, Name = "Mary Williams" },
                        };
            */
            if (customers == null)
                return HttpNotFound();

            return View(customers);

        }

        }

    }

