using eShop.CoreBusiness.Models;

namespace eShop.UseCases.OrderConfirmationUseCase
{
    public interface IViewOrderConfirmationUseCase
    {
        Order Execute(string uniqueId);
    }
}