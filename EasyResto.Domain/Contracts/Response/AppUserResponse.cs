namespace EasyResto.Domain.Contracts.Response
{
    public class AppUserResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public bool IsActive { get; set; }

        public List<RoleResponse> Roles { get; set; } = new List<RoleResponse>();
    }
}
