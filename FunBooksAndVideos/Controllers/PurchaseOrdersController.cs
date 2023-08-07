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
        private readonly PurchaseOrderProcessor _purchaseOrderProcessor;
        private readonly List<Customer> _customers = new List<Customer>();
        private readonly List<PurchaseOrder> _purchaseOrders = new List<PurchaseOrder>();


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


        // POST /api/customers/{customerId}/memberships
        [HttpPost("customers/{customerId}/memberships")]
        public IActionResult AddMembership(int customerId, [FromBody] MembershipType membershipType)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == customerId);
            if (customer == null)
            {
                return NotFound();
            }

            var membership = new Membership(membershipType) { IsActivated = false };
            customer.Memberships.Add(membership);

            return Ok(membership);
        }


        // PUT /api/customers/{customerId}/memberships/{membershipId}/activate
        [HttpPut("customers/{customerId}/memberships/{membershipId}/activate")]
        public IActionResult ActivateMembership(int customerId, int membershipId)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == customerId);
            if (customer == null)
            {
                return NotFound();
            }

            var membership = customer.Memberships.FirstOrDefault(m => m.MembershipId == membershipId);
            if (membership == null)
            {
                return NotFound();
            }

            membership.IsActivated = true;

            return Ok($"Membership with ID {membershipId} has been activated for customer with ID {customerId}.");
        }

        // GET /api/customers/{customerId}/orders
        [HttpGet("customers/{customerId}/orders")]
        public IActionResult GetOrderHistory(int customerId)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == customerId);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(_purchaseOrders.Where(po => po.CustomerId == customerId));
        }


        // GET /api/purchase_orders/{orderId}
        [HttpGet("purchase_orders/{orderId}")]
        public IActionResult GetPurchaseOrder(int orderId)
        {
            var purchaseOrder = _purchaseOrders.FirstOrDefault(po => po.POId == orderId);
            if (purchaseOrder == null)
            {
                return NotFound();
            }

            return Ok(purchaseOrder);
        }


        // PUT /api/purchase_orders/{orderId}/items
        [HttpPut("purchase_orders/{orderId}/items")]
        public IActionResult AddItemsToPurchaseOrder(int orderId, [FromBody] List<PurchaseOrderItem> items)
        {
            var purchaseOrder = _purchaseOrders.FirstOrDefault(po => po.POId == orderId);
            if (purchaseOrder == null)
            {
                return NotFound();
            }

            purchaseOrder.Items.AddRange(items);

            return Ok($"Items added to purchase order with ID {orderId}.");
        }


        [HttpGet("customers/{customerId}/memberships")]
        public IActionResult GetMemberships(int customerId)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == customerId);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer.Memberships);
        }

        // DELETE /api/purchase_orders/{orderId}
        [HttpDelete("purchase_orders/{orderId}")]
        public IActionResult CancelPurchaseOrder(int orderId)
        {
            var purchaseOrder = _purchaseOrders.FirstOrDefault(po => po.POId == orderId);
            if (purchaseOrder == null)
            {
                return NotFound();
            }

            // Implement cancellation logic here, e.g., setting a status field to "Cancelled."

            return Ok($"Purchase order with ID {orderId} has been cancelled.");
        }


        // GET /api/purchase_orders/{orderId}/shipping_slip
        [HttpGet("purchase_orders/{orderId}/shipping_slip")]
        public IActionResult GetShippingSlip(int orderId)
        {
            var purchaseOrder = _purchaseOrders.FirstOrDefault(po => po.POId == orderId);
            if (purchaseOrder == null)
            {
                return NotFound();
            }

            return Ok(purchaseOrder.ShippingSlip);
        }
    }
}
