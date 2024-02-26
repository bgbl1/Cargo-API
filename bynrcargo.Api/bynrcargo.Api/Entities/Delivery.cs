

namespace bynrcargo.Api.Entities
{
    public class Delivery

    {
        public Guid DeliveryId { get; set; }
        public string DeliveryCode { get; init; }
        public string ReceiverAddress { get; set; }

        public string SenderAddress { get; set; }
        
        public DeliveryStatus Status { get;  set; }
        
        public Delivery() {
            Status = DeliveryStatus.Created;
        }

        public void SetStatusCanceled() { 
        
        if(Status != DeliveryStatus.Created)
            {
                throw new Exception("Mevcut statude bu delivery iptal edilemez!");

            }
            Status = DeliveryStatus.Canceled;
        
        }

            }

    
}

