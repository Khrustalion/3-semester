namespace Contracts.Admins;

public interface ICurrentAdminService
{
    Models.Admins.Admin? Admin { get; }
}