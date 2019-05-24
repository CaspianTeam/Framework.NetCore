namespace CaspianTeam.Framework.NetCore.Models.Frameworks.Services.EmailService
{
    public class EmailOptionsModel
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string Host { get; set; }
        public int Timeout { get; set; }
    }
}
