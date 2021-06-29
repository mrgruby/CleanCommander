﻿using AutoMapper;
using CleanCommander.Application.Contracts.Persistence;
using CleanCommander.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Platforms.Queries.GetPlatformsList
{
    public class GetPlatformsListQueryHandler : IRequestHandler<GetPlatformsListQuery, List<GetPlatformsListReturnModel>>
    {
        private readonly IGenericRepository<PromptPlatform> _repo;
        private readonly IMapper _mapper;

        public GetPlatformsListQueryHandler(IGenericRepository<PromptPlatform> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public Task<List<GetPlatformsListReturnModel>> Handle(GetPlatformsListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
