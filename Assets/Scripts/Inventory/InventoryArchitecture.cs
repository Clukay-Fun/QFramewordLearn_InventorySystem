using QFramework;

namespace QFramework.Inventory
{
    /// <summary>
    /// ∂®“Âº‹ππ
    /// </summary>
    public class InventoryArchitecture : Architecture<InventoryArchitecture>
    {
        protected override void Init()
        {
            RegisterModel(new InventoryModel());
            RegisterUtility<IStorage>(new InventoryStorage());
        }
    }
}
