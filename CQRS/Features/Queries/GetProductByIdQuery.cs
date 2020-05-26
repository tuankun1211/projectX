using CQRS.Contexts;
using CQRS.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Features.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
        {
            private readonly ICQRSContext _context;
            public GetProductByIdQueryHandler(ICQRSContext context)
            {
                _context = context;
            }
            public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                var product = _context.Products.Where(a => a.Id == query.Id).FirstOrDefault();
                if (product == null) return null;
                return product;
            }
        }
    }
}
