namespace EasyResto.Domain.Contracts.Response
{
    public class AuthResponse
    {
        public string Name { get; set; }

        public string Username { get; set; }

        public List<string> Roles { get; set; } = new List<string>();

        public List<string> Privileges { get; set; } = new List<string>();

        public string Token { get; set; }
    }
}
