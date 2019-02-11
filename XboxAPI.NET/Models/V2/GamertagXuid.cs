namespace XboxAPI.NET.Models.V2
{
    public class GamertagXuid
    {
        public int error_code { get; set; }

        public string error_message { get; set; }

        public bool success { get; set; }

        public string xuid { get; set; }
    }
}