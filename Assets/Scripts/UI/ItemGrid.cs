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
            // �����Ʒ�����㲥��ʾ��Ʒ��Ϣ
            TypeEventSystem.Global.Send(data);
        }
	}
}
