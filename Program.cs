using FunctionApp1.Helper;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication(worker =>
    {
        worker.UseMiddleware<ErrorHandlerMiddleware>();
    }).Build();

host.Run();






