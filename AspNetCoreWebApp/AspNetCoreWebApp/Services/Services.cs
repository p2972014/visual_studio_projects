using Microsoft.Extensions.Hosting;

namespace Services
{
    public interface ITransientService
    {
        Guid GetOperationID();
    }
    public interface IScopedService
    {
        Guid GetOperationID();
    }
    public interface ISingletonService
    {
        Guid GetOperationID();
    }

    public class OperationService :
        ITransientService,
        IScopedService,
        ISingletonService
    {
        Guid id;
        public OperationService()
        {
            id = Guid.NewGuid();
        }
        public Guid GetOperationID()
        {
            return id;
        }
    }

    public class myHostedService : IHostedService
    {
        private readonly ILogger<myHostedService> _logger;
        public myHostedService(ILogger<myHostedService> logger)
        {
            _logger = logger;
            _logger.LogInformation("myHostedService. init");
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("myHostedService. StartAsync");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("myHostedService. StopAsync");
            return Task.CompletedTask;
        }
    }
}