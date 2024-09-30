using System.ComponentModel;
using Microsoft.Extensions.Hosting;

namespace Alrazi.Services
{
    public class CheckIdel : IHostedService, IDisposable
    {
        private Timer _timer;
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(3));
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            Task.Run(DoWorkAsync);
        }

        private async Task DoWorkAsync()
        {
            DateTime currentTime = DateTime.Now;
            if (currentTime.Hour >= 1 && currentTime.Hour < 6)
                return;

            try
            {
                using (var handler = new HttpClientHandler())
                {
                    // Ignore SSL certificate errors
                    handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

                    using (var client = new HttpClient(handler))
                    {
                        string url = "https://alrazi.visual-host.com";
                        HttpResponseMessage response = await client.GetAsync(url);
                    }
                }
            }
            catch(Exception ex)
            {
                
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
