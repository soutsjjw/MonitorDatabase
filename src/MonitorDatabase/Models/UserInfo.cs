using System;

namespace MonitorDatabase.Models
{
    public class UserInfo
    {
        public int Uid { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public string Company { get; set; }
        public string Area { get; set; }
        public string ImageUrl { get; set; }
        public string Remake { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
