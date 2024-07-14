using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.CQRS
{
    internal interface IQuery:IQuery<Unit>
    {
    }
    internal interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
