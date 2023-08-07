using FunBooksAndVideos.Models;

namespace FunBooksAndVideos.Processors
{

    public class ProcessorOutput
    {
        public string ShippingSlip { set; get; }
        public string MembershipDetails { set; get; }
    }

    public class PurchaseOrderProcessor
    {
        public ProcessorOutput ProcessPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            Customer customer = new Customer(purchaseOrder.CustomerId);

            // Applying BR1
            ActivateMembership(customer, purchaseOrder.Items);

            // Applying BR2
            GenerateShippingSlip(purchaseOrder);

            return GetOutput(customer, purchaseOrder);

        }


        #region Private Methods

        //BR1.If the purchase order contains a membership, it has to be activated in the customer account immediately.
        private void ActivateMembership(Customer customer, List<PurchaseOrderItem> items)
        {
            foreach (var item in items)
            {
                if (item.MembershipType.HasValue)
                {
                    Membership membership = new Membership(item.MembershipType) {IsActivated = true};
                    customer.Memberships.Add(membership);
                }
            }
        }

        //BR2. If the purchase order contains a physical product a shipping slip has to be generated. 
        private void GenerateShippingSlip(PurchaseOrder purchaseOrder)
        {
            List<PurchaseOrderItem> items = purchaseOrder.Items.Where((item) => item.Product != null).ToList();
            if (items.Count != 0)
            {
                purchaseOrder.ShippingSlip = $"Slip having {items.Count} items to be shipped";
            }
        }

        private ProcessorOutput GetOutput(Customer customer, PurchaseOrder purchaseOrder)
        {
            string membershipDetails = "";
            customer.Memberships.ForEach((membership) =>
            {
                membershipDetails += $"Activated {membership.MembershipType} for customer id: {customer.Id}\n ";

            });

            return new ProcessorOutput()
            {
                ShippingSlip = purchaseOrder.ShippingSlip,
                MembershipDetails = membershipDetails
            };
        }

        #endregion

    }
}
