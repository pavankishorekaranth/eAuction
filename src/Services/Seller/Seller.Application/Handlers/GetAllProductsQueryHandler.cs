﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Seller.Application.Contracts.Persistence;
using Seller.Application.Queries;
using Seller.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seller.Application.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDetails>>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllProductsQueryHandler> _logger;

        public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper, ILogger<GetAllProductsQueryHandler> logger)
        {
            this.productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<ProductDetails>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var productList = await productRepository.GetProducts();
            if (productList == null)
            {
                return null;
            }
            return _mapper.Map<List<ProductDetails>>(productList);
        }
    }
}