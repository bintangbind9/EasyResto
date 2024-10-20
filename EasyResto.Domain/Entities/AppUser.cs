namespace EasyResto.Domain.Entities
{
    public class AppUser
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
