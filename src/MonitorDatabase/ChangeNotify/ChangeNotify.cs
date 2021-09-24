using Microsoft.AspNetCore.SignalR;
using MonitorDatabase.Hubs;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MonitorDatabase
{
    public class ChangeNotify : IChangeNotify
    {
        public string TableName { get; set; }

        public string ConnectionString { get; set; }

        private bool IsEcecuted { get; set; } = false;

        private IHubContext<DBHub> _hubContext { get; set; }

        public ChangeNotify(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        public void Start(IHubContext<DBHub> hubContext)
        {
            Console.WriteLine("Starting SQL dependency");

            this._hubContext = hubContext;
            if (!IsEcecuted)
            {
                SqlDependency.Stop(ConnectionString);
                SqlDependency.Start(ConnectionString);

                IsEcecuted = true;
                StartListening();
            }
        }

        private void StartListening()
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT [Uid],[Name],[Tel],[Company],[Area],[ImageUrl],[Remake],[CreateTime] FROM [dbo].[UserInfos]";

                    cmd.Notification = null;

                    SqlDependency dep = new SqlDependency(cmd);
                    dep.OnChange += Dep_OnChange;

                    conn.Open();
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
                    {
                        DataTable sqlDt = new DataTable();
                        sqlDataAdapter.Fill(sqlDt);

                        SendAsync(sqlDt).Wait();
                    }
                }
            }
            Console.WriteLine("Listening...");
        }

        public async Task SendAsync(DataTable table)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(table);

            await _hubContext.Clients.All.SendAsync("DataChange", JSONString);
        }

        public async Task SendAsync()
        {
            await _hubContext.Clients.All.SendAsync("DataChange", "CCC", $"Home page loaded at: {DateTime.Now}");
        }

        private void Dep_OnChange(object sender, SqlNotificationEventArgs e)
        {
            Console.WriteLine("Change caught! Triggering update to WebServer...");

            StartListening();
        }
    }
}
