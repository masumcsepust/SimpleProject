using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Models;
using SimpleAPI.Services;

namespace SimpleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers = new Customer() {Id=1, Name="masum", Address="sfasf", Emaily="sdfasf@gmail.com"}; //_customerService.List();

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }

            var model = await _customerService.GetCustomer(id.Value);
            if(model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        // [HttpPost]
        // public IActionResult Create()
        // {
        //     return View(nameof(Edit));
        // }

        // [HttpPost]
        // public async Task<IActionResult> Create(CustomerModel model)
        // {
        //     return await SaveCustomer(model);
        // }

        // [Authorize(Roles = "Admin")]
        // [HttpGet]
        // public async Task<IActionResult> Edit(int? id)
        // {
        //     if (id == null)
        //     {
        //         return BadRequest();
        //     }

        //     var model = await _customerService.GetCustomer(id.Value);
        //     if (model == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(model);
        // }

        // [Authorize]
        // [HttpPost]
        // public async Task<IActionResult> Edit(CustomerModel model)
        // {
        //     return await SaveCustomer(model);
        // }

        // [NonAction]
        // private async Task<IActionResult> SaveCustomer(CustomerModel model)
        // {
        //     if (model == null)
        //     {
        //         return BadRequest();
        //     }

        //     if(!ModelState.IsValid)
        //     {
        //         return View(nameof(Edit), model);
        //     }

        //     await _customerService.SaveCustomer(model);

        //     return RedirectToAction(nameof(CustomersController.Index));
        // }
    }
}