namespace Models.Entities.DTOs
{
    public sealed class ExampleDto : IDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public bool Equals(IDto? other)
        {
            return other is ExampleDto dto && Name == dto.Name;
        }
    }
}
