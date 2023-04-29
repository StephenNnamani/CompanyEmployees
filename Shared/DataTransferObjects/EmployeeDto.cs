namespace Shared.DataTransferObjects
{
    [Serializable]
    public record EmployeeDto(Guid Id, string Name, int age, string Position);
}
