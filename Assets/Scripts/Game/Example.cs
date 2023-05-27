using UnityEngine;
using QFramework;

namespace QFramework.Inventory
{

    public partial class Example : MonoBehaviour
    {
        private void Awake()
        {
            ResKit.Init();
        }
        Item item1;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                item1 = new Item();
                item1.Init(1, "item1", 1);
                TypeEventSystem.Global.Send(InventoryEventType.AddItem, item1);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                item1 = new Item();
                item1.Init(1, "item1", 1);
                TypeEventSystem.Global.Send(InventoryEventType.RemoveItem, item1);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                item1 = new Item();
                item1.Init(2, "item2", 1);
                TypeEventSystem.Global.Send(InventoryEventType.AddItem, item1);
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                UIKit.OpenPanel("InventoryPanel");
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                UIKit.HidePanel("InventoryPanel");
            }
        }
    }
}
