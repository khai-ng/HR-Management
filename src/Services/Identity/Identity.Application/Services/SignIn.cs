﻿using Core.Autofac;
using Core.Result;
using Identity.Application.Abstractions;
using Identity.Application.Extensions;
using Identity.Domain.Entities;
using MediatR;

namespace Identity.Application.Services
{
    public class SignIn : IRequestHandler<SignInRequest, AppResult<string>>, ITransient
    {
        private readonly IAppDbContext _context;
        public SignIn(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<AppResult<string>> Handle(
            SignInRequest request, 
            CancellationToken ct)
        {
            var pwdGen = PasswordExtension.GeneratePassword(request.Password);
            var user = new User 
            { 
                UserName = request.UserName,
                Email = "",
                PasswordHash = pwdGen.Password,
                SecurityStamp = pwdGen.PasswordSalt

            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync(ct);
            return AppResult.Success("Sign In Sucess");
        }
    }
}
