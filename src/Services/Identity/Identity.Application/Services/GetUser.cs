﻿using Core.Autofac;
using Core.Result.AppResults;
using Core.Result.Paginations;
using Identity.Application.Abstractions;
using Identity.Domain.Entities.UserAggrigate;
using MediatR;

namespace Identity.Application.Services
{
    public class GetUser : IRequestHandler<GetUserRequest, AppResult<PagingResponse<User>>>, ITransient
    {
        private readonly IUserRepository _userRepository;
        public GetUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<AppResult<PagingResponse<User>>> Handle(
            GetUserRequest request,
            CancellationToken ct)
        {
            var rs = await _userRepository.GetUsersPagingAsync(request);
            return AppResult.Success(rs);
		}
    }
}