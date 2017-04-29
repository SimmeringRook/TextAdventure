namespace Engine.Core.Items
{
    public class Item
    {
        public int ID { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        
        public Item(int id, string name, string description)
        {
            ID = id;
            Name = name;
            Description = description;
        }
    }
}