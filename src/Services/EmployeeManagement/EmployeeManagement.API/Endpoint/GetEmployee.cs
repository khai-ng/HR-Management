﻿using EmployeeManagement.Application.Services;
using EmployeeManagement.Domain.Entities;
using FastEndpoints;
using MediatR;
using Core.Result;
using Core.AspNet.Result;

namespace EmployeeManagement.API.Endpoint
{
    public class GetEmployeeEndpoint : Endpoint<GetEmployeeRequest, AppResult<PagingResponse<Employee>>>
    {
        private readonly IMediator _mediator;
        public GetEmployeeEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override void Configure()
        {
            Get("employee/get");
        }

        public override async Task HandleAsync(GetEmployeeRequest request, CancellationToken ct)
        {
            var result = await _mediator.Send(request, ct);
            await SendResultAsync(result.ToHttpResult());
        }
    }
}
