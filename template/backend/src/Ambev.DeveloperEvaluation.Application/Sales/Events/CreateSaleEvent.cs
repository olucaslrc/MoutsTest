using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Events;
public class CreateSaleEvent : IRequest
{
    public Sale Sale { get; set; }
    public CreateSaleEvent(Sale sale)
    {
        Sale = sale;
    }
}

