namespace Contracts.Admins;

public interface IAdminService
{
    public AdminOperationResult Login(string password);

    public AdminOperationResult ChangePassword(string newPassword);

    public void Logout();
}