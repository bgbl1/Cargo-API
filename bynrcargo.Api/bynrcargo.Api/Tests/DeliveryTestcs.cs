namespace bynrcargo.Api.Tests;
using bynrcargo.Api.Entities;
using Xunit;

public class DeliveryTests
{
    [Fact]
    public void SetStatusCanceled_WhenStatusIsCreated_StatusSetToCanceled()
    {
        // Arrange
        var delivery = new Delivery();
        delivery.Status = DeliveryStatus.Created;

        // Act
        delivery.SetStatusCanceled();

        // Assert
        Assert.Equal(DeliveryStatus.Canceled, delivery.Status);
    }

    [Fact]
    public void SetStatusCanceled_WhenStatusIsNotCreated_ExceptionThrown()
    {
        // Arrange
        var delivery = new Delivery();
        delivery.Status = DeliveryStatus.Delivered; 

        // Act 
        var exception = Assert.Throws<Exception>(() => delivery.SetStatusCanceled());

        // Assert
        Assert.Equal("Mevcut statude bu delivery iptal edilemez!", exception.Message);
    }
}
