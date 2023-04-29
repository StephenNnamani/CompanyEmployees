namespace Shared.DataTransferObjects
{
    [Serializable]
    public record EmployeeDto
    { 
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public int age { get; init; }
        public string? Position { get; init; }
    };
}
