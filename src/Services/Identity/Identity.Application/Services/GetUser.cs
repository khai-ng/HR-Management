﻿using Core.Autofac;
using Core.Result;
using Identity.Application.Abstractions;
using Identity.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Services
{
    public class GetUser : IRequestHandler<GetUserRequest, AppResult<PagingResponse<User>>>, ITransient
    {
        private readonly IAppDbContext _context;
        public GetUser(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<AppResult<PagingResponse<User>>> Handle(
            GetUserRequest request,
            CancellationToken ct)
        {
            var pagingResult = PagingTyped
                .From(request)
                .Paging(await _context.Users.ToListAsync());

            return AppResult.Success(pagingResult);
		}
    }
}