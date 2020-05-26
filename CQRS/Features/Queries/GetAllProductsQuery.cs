using CQRS.Contexts;
using CQRS.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Features.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
        {
            private readonly ICQRSContext _context;
            public GetAllProductsQueryHandler(ICQRSContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
            {
                var productList = await _context.Products.ToListAsync();
                if (productList == null)
                {
                    return null;
                }
                return productList.AsReadOnly();
            }
        }
    }
}
