namespace Abstractions.Repositories;

public interface IAdminRepository
{
    public int? GetPassword();

    public void ChangePassword(int newPassword);

    public void SetDefaultPassword(int defaultPassword);
}