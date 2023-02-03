namespace GUI1.Model
{
    public class CharacterAbility
    {
        public string Name { get; set; }
        public int CurrentLevel { get; set; }
        public int MaxLevel { get; set; }

        public override string ToString()
        {
            return $"{this.Name}: {this.CurrentLevel}/{this.MaxLevel}";
        }
    }
}
