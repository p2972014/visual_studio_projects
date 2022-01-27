using Microsoft.AspNetCore.SignalR;

namespace AspNetCoreSignalR.Hubs
{
    public class MyHub : Hub
    {
        public async Task ServerMethod1(string name, string message)
        {
            var q = this.Context;

            var q2 = name;
            var q3 = message + @" " + DateTime.Now.Ticks;

            await Clients
                //.All
                .Caller
                .SendAsync("ClientMethod1", q2, q3);
        }
    }
}
