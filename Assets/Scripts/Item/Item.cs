namespace QFramework.Inventory
{
    /// <summary>
    /// µ¿æﬂ¿‡
    /// </summary>
    public class Item
    {
        public void Init(int id, string name, int count)
        {
            itemID = id;
            itemName = name;
            itemCount = count;
        }
        public int itemID;
        public string itemName;
        public int itemCount;
    }
}
