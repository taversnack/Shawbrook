using FunBooksAndVideos.Enums;
using FunBooksAndVideos.Models;
using FunBooksAndVideos.Repository.Interface;

namespace FunBooksAndVideos.Processors
{
    public class PurchaseOrderProcessor
    {

        private readonly IItemLineRepository _itemLineRepository;
        private readonly IMembershipRepository _membershipRepository;

        public PurchaseOrderProcessor() { }
        public PurchaseOrderProcessor(IItemLineRepository itemLineRepository, IMembershipRepository membershipRepository)
        {
            _itemLineRepository = itemLineRepository;
            _membershipRepository = membershipRepository;
        }


        public void ProcessPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            // Retrieve the item lines associated with the purchase order from the database.
            var itemLines = _itemLineRepository.GetItemLinesByOrderId(purchaseOrder.OrderId);

            if (itemLines.Any(itemLine => itemLine.MembershipId != null))
            {
                ActivateMembership(purchaseOrder.CustomerId, itemLines);
            }

            if (itemLines.Any(itemLine => itemLine.Product.Type == ProductType.Physical))
            {
                GenerateShippingSlip(purchaseOrder.OrderId);
            }
        }

        private void ActivateMembership(int customerId, List<ItemLine> itemLines)
        {
            foreach (var itemLine in itemLines)
            {
                if (itemLine.MembershipId.HasValue)
                {
                    // Fetch the membership status data from the database based on customerId and membershipId.
                    MembershipStatus membershipStatus = _membershipRepository.GetMembershipStatus(customerId, itemLine.MembershipId.Value);

                    if (membershipStatus != null)
                    {
                        membershipStatus.IsActive = true;

                        // Update the membership status in the database.
                        _membershipRepository.UpdateMembershipStatus(membershipStatus);
                    }
                }
            }
        }

        private void GenerateShippingSlip(int orderId)
        {
           
            var shippingSlip = new ShippingSlip
            {
                OrderId = orderId,
                CreatedAt = DateTime.UtcNow
                // Additional shipping slip data can be added here.
            };

            // Store the shipping slip in the database or take appropriate actions.
            SaveShippingSlipToDatabase(shippingSlip);
        }

        private MembershipStatus GetMembershipStatusFromDatabase(int customerId, int membershipId)
        {
            // Query the database to get the membership status for the customer and membershipId.
            // For the sake of example, we return a mock MembershipStatus object.
            return new MembershipStatus
            {
                CustomerId = customerId,
                MembershipId = membershipId,
                IsActive = false
            };
        }


        private void UpdateMembershipStatusInDatabase(MembershipStatus membershipStatus)
        {
            // Update the membership status in the database.
            // For the sake of example, we do nothing in this mock method.
        }

        private void SaveShippingSlipToDatabase(ShippingSlip shippingSlip)
        {
            // Save the shipping slip to the database or perform other required actions.
            // For the sake of example, we do nothing in this mock method.
        }

    }
}