namespace A3_TPLReflectionAttributes.Attributes
{
    public class User
    {
        public int Id { get; set; }

        [MaxLengthNo(10)]
        public string Name { get; set; }

        public User( int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
