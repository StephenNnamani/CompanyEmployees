namespace Shared.DataTransferObjects
{
    [Serializable]
    public record CompanyDto(Guid Id, string Name, int Employees, string FullAddress);
}
