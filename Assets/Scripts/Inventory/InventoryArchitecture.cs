using QFramework;

namespace QFramework.Inventory
{
    /// <summary>
    /// ����ܹ�
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
