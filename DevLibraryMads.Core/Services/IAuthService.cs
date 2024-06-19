namespace DevLibraryMads.Core.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(string userName, string role);
        string ComputeSha256Hash(string password);
    }
}
