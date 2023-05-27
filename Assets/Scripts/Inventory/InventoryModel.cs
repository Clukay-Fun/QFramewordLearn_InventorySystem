using QFramework;
using System.Collections.Generic;

namespace QFramework.Inventory
{
    public class InventoryModel : AbstractModel, IModel
    {
        /// <summary>
        /// 存储物品的可绑定属性
        /// </summary>
        public BindableProperty<Item> item = new BindableProperty<Item>();

        /// <summary>
        /// 存储所有物品的列表
        /// </summary>
        public List<Item> itemList = new List<Item>();

        /// <summary>
        /// 当物品发生变化时发出的事件
        /// </summary>
        public EasyEvent OnItemChange = new EasyEvent();

        protected override void OnInit()
        {
            var storage = this.GetUtility<IStorage>();

            // 从持久化数据中加载物品列表
            if (storage.LoadData<List<Item>>("InventoryData") != null)
                itemList = storage.LoadData<List<Item>>("InventoryData");

            // 当新物品添加时，保存物品列表到持久化数据中
            item.Register(newItem =>
            {
                if (newItem != null)
                {
                    storage.SaveData(itemList, "InventoryData");
                }
            });
        }
    }
}
