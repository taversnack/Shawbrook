using FunBooksAndVideos.DTOs;
using FunBooksAndVideos.Enums;
using FunBooksAndVideos.Models;
using FunBooksAndVideos.Processors;
using Microsoft.AspNetCore.Mvc;

namespace FunBooksAndVideos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrdersController : ControllerBase
    {
        private List<PurchaseOrder> _purchaseOrders = new List<PurchaseOrder>();


        [HttpPost]
        public IActionResult CreatePurchaseOrder([FromBody] PurchaseOrderDto purchaseOrderDto)
        {
            var purchaseOrder = new PurchaseOrder
            {
                CustomerId = purchaseOrderDto.CustomerId,
                TotalPrice = purchaseOrderDto.TotalPrice
            };

            _purchaseOrders.Add(purchaseOrder);

            return Ok(purchaseOrder);
        }

        [HttpPost("{orderId}/item")]
        public IActionResult AddItemToPurchaseOrder(int orderId, [FromBody] ItemLineDto itemLineDto)
        {
            // Find the purchase order by orderId (This will be replaced by a data access mechanism).
            var purchaseOrder = _purchaseOrders.FirstOrDefault(po => po.OrderId == orderId);

            if (purchaseOrder == null)
            {
                return NotFound("Purchase Order not found.");
            }

            var itemLine = new ItemLine
            {
                OrderId = orderId,
                ProductId = itemLineDto.ProductId,
                MembershipId = itemLineDto.MembershipId
            };

            // In a real application, you would validate the itemLineDto data and handle any business rules here.

            purchaseOrder.AddItemLine(itemLine);

            return Ok(itemLine);
        }

    }
}