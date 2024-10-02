using Microsoft.AspNetCore.SignalR.Client;
using RealTimeChatApp.UI.Entities;

namespace RealTimeChatApp.UI.Services
{
    public class SignalRService
    {
        private HubConnection? hubConnection;

       

        public  HubConnection ConnectHub(string url)
        {
            hubConnection = new HubConnectionBuilder()
           .WithUrl(url)
           .Build();


            return hubConnection;
        }


        public async Task StartAsync(HubConnection? hubConnection)
        {
            if (hubConnection == null)
            {
                throw new ArgumentNullException(nameof(hubConnection));
            }
            else
              await hubConnection.StartAsync();

        }


        public async ValueTask DisposeAsync()
        {
            if (hubConnection != null)
            {
                await Task.Delay(3000);


                await hubConnection.DisposeAsync();
            }
            else
                throw new Exception("Bağlantı Boş");
        }



    }
}
