using System.Collections;

namespace Shared.DataTransferObjects
{
    public record CompanyDto(Guid Id, string Name, int Employees, string FullAddress);
}
