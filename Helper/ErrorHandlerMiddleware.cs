using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionApp1.Helper
{
    public sealed class ErrorHandlerMiddleware : IFunctionsWorkerMiddleware
    {
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(ILogger<ErrorHandlerMiddleware> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception error)
            {
                var _logger = context.GetLogger<ErrorHandlerMiddleware>();

                switch (error)
                {
                    case KeyNotFoundException e:
                        //Do Something
                        break;
                }

                _logger.LogError(error.Message);
            }
        }
    }
}
