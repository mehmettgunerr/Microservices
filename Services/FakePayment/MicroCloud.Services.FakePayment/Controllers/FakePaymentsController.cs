using MicroCloud.Services.FakePayment.Models;
using MicroCloud.Shared.ControllerBases;
using MicroCloud.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroCloud.Services.FakePayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakePaymentsController : CustomBaseController
    {
        [HttpPost]
        public IActionResult ReceivePayment(PaymentDto paymentDto)
        {
            //paymentDto ile ödeme işlemi yap
            return CreateActionResultInstance(Response<NoContent>.Success(200));
        }
    }
}
