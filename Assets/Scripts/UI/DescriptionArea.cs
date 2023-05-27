using UnityEngine;
using QFramework;

namespace QFramework.Inventory
{
	public partial class DescriptionArea : ViewController
	{
        private void Awake()
        {
            // 发送广播，当物品点击时显示信息
            TypeEventSystem.Global.Register<Item>(UpdateItemDescription).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        public void UpdateItemDescription(Item item)
        {
            ItemName.text = item.itemName;
            ItemCount.text = "物品数量：" + item.itemCount;
        }
    }
}
