namespace EasyResto.Application.Service
{
    public interface IPasswordService
    {
        public string HashPassword(string password);

        public bool VerifyPassword(string hashedPassword, string password);
    }
}
