namespace GUI1.Model
{
    public class MapField
    {
        public string Filename { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Description { get; set; }
        public bool Passable { get; set; } = true;
    }
}
