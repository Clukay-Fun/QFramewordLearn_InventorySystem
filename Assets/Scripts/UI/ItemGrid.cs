using UnityEngine;
using QFramework;
using UnityEngine.EventSystems;

namespace QFramework.Inventory
{
	public partial class ItemGrid : ViewController, IPointerClickHandler
    {
        public Item data;
        public void OnPointerClick(PointerEventData eventData)
        {
            // 点击物品触发广播显示物品信息
            TypeEventSystem.Global.Send(data);
        }
	}
}
