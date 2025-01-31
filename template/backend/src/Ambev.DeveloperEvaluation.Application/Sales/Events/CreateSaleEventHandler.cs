using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Events;
public class CreateSaleEventHandler : IRequestHandler<CreateSaleEvent>
{
    public async Task Handle(CreateSaleEvent request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

