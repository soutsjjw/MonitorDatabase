using Microsoft.AspNetCore.SignalR;
using MonitorDatabase.Hubs;

namespace MonitorDatabase
{
    public interface IChangeNotify
    {
        public string TableName { get; set; }

        public string ConnectionString { get; set; }


        public void Start(IHubContext<DBHub> hubContext);
    }
}
