namespace Dogs.Core.Entities
{
    public class Dog : BaseEntity
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public float TailLenght { get; set; }
        public float Weight { get; set; }
    }
}
