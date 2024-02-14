namespace bynrcargo.Api.Contracts.Request
{
    public class AddDeliveryRequest
    {
        public string DeliveryCode { get; set; }
        public string SenderAdress { get; set; }
        public string ReceiverAdress { get; set; }
    }
}
