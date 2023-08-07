using FunBooksAndVideos.Models;
using FunBooksAndVideos.Processors;
using Microsoft.AspNetCore.Mvc;

namespace FunBooksAndVideos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrdersController : ControllerBase
    {
        private readonly PurchaseOrderProcessor _purchaseOrderProcessor;


        public PurchaseOrdersController(PurchaseOrderProcessor purchaseOrderProcessor)
        {
            _purchaseOrderProcessor = purchaseOrderProcessor;
        }


        [HttpPost]
        public IActionResult ProcessPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            var processOrder = _purchaseOrderProcessor.ProcessPurchaseOrder(purchaseOrder);
            return Ok(processOrder);
        }
    }
}
