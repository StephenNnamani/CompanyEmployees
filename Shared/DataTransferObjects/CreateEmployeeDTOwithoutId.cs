namespace Shared.DataTransferObjects
{

    [Serializable]
    public record CreateEmployeeDTOwithoutId
    {
        public string? Name { get; init; }
        public int age { get; init; }
        public string? Position { get; init; }
    }

}
