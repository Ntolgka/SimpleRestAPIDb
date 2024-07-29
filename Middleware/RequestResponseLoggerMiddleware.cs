﻿using Serilog;
namespace Week2_Assessment.Middleware;

public class RequestResponseLoggerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestResponseLoggerMiddleware> _logger;

    public RequestResponseLoggerMiddleware(RequestDelegate next, ILogger<RequestResponseLoggerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        LogRequest(context.Request);

        // Continue down the Middleware pipeline
        await _next(context);
        
        LogResponse(context.Response);
    }

    private void LogRequest(HttpRequest request)
    {
        var requestInfo = 
            $"Log Request:\n" + 
            $"Method: {request.Method}\n" +
            $"Request Endpoint: {request.Scheme}://{request.Host}{request.Path} {request.QueryString}\n";
        
        _logger.LogInformation(requestInfo);
    }

    private void LogResponse(HttpResponse response)
    {
        var responseInfo = 
            $"Log Response:\n" +
            $"Status Code: {response.StatusCode}\n";
        
        _logger.LogInformation(responseInfo);
    }
}