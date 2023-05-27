using UnityEngine;
using QFramework;

namespace QFramework.Inventory
{
	public partial class InventoryController : MonoBehaviour, IController
    {
        private void Awake()
        {
            // 发送 改变物体时发生变化 的广播事件
            TypeEventSystem.Global.Register<InventoryEventType, Item>(ChangeItem).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        /// <summary>
        /// 处理物品变化事件，包括添加和移除物品。
        /// </summary>
        /// <param name="eventType">事件类型，指示是添加还是移除物品</param>
        /// <param name="item">被添加或移除的物品</param>
        private void ChangeItem(InventoryEventType eventType, Item item)
        {
            // 根据事件类型执行相应的操作
            switch (eventType)
            {
                case InventoryEventType.AddItem:
                    // 发送添加物品的命令
                    this.SendCommand(new AddItemCommand(item));
                    break;
                case InventoryEventType.RemoveItem:
                    // 发送移除物品的命令
                    this.SendCommand(new RemoveItemCommand(item));
                    break;
            }
        }


        public IArchitecture GetArchitecture()
        {
            return InventoryArchitecture.Interface;
        }
    }
}
