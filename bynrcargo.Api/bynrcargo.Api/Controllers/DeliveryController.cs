
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using bynrcargo.Api.Contracts.Request;
using bynrcargo.Api.Contracts.Response; 
using Dapper;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq;
using System.Data;

namespace bynrcargo.Api.Entities
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryController : ControllerBase
    {
        private readonly string _connectionString;
        public DeliveryController(string connectionString)
        {
            _connectionString = connectionString;
        }

        
        [HttpGet("List")]
        public async Task<IActionResult> GetList()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var deliveries = await connection.QueryAsync<Delivery>("SELECT * FROM Deliveries");
                var deliveryList = deliveries.ToList();

                if (deliveryList.Count == 0)
                {
                    return NotFound("Uygun Siparis Bulunamadı");
                }
                return Ok(deliveryList);
            }
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddDeliveryRequest request)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var existingDelivery = await connection.QueryFirstOrDefaultAsync<Delivery>("SELECT * FROM Deliveries WHERE DeliveryCode = @DeliveryCode", new { request.DeliveryCode });
                if (existingDelivery != null)
                    
                {

                    return Conflict();
                }
                Delivery delivery = new Delivery
                {
                    DeliveryCode = request.DeliveryCode,
                    ReceiverAddress = request.ReceiverAdress,
                    SenderAddress = request.SenderAdress

                };

                await connection.ExecuteAsync("INSERT INTO Deliveries (DeliveryCode, ReceiverAddress, SenderAddress, Status) VALUES (@DeliveryCode, @ReceiverAddress, @SenderAddress, @Status)", delivery);
                return Ok();
            }
        }
        [HttpGet("Status/{deliveryCode}")]
        public async Task<IActionResult> GetStatus(string deliveryCode)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var delivery = await connection.QueryFirstOrDefaultAsync<Delivery>("SELECT * FROM Deliveries WHERE DeliveryCode = @DeliveryCode", new { DeliveryCode = deliveryCode });
                if (delivery == null)
                {
                    return NotFound();
                }
                GetStatusResponse response = new GetStatusResponse
                {
                    DeliveryCode = delivery.DeliveryCode,
                    Status = delivery.Status,
                    StatusDescription = delivery.Status.ToString()

                };
                return Ok(response);
            }
        }
        [HttpDelete("Cancel/{deliveryCode}")]

        public async Task<IActionResult> Cancel(string deliveryCode)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var delivery = await connection.QueryFirstOrDefaultAsync<Delivery>("SELECT * FROM Deliveries WHERE DeliveryCode = @DeliveryCode", new { DeliveryCode = deliveryCode });
                if (delivery == null)
                {
                    return NotFound("Boyle bir teslimat mevcut değil!");
                }
                delivery.SetStatusCanceled();
                return Accepted();
            }
        }
    
    }
}
