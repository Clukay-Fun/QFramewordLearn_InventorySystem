using QFramework;
using System.Collections.Generic;
using System.Diagnostics;

namespace QFramework.Inventory
{
    // ÒýÈë Command
    public class InventoryCommand : AbstractCommand
    {
        protected InventoryModel Model;
        protected List<Item> items;
        protected Item currentItem;
        protected Item tempItem;
        protected int count = 0;

        protected override void OnExecute()
        {
        }
    }

    public class AddItemCommand : InventoryCommand
    {
        public AddItemCommand(Item item)
        {
            tempItem = item;
            count = tempItem.itemCount;
        }
        protected override void OnExecute()
        {
            Model = this.GetModel<InventoryModel>();
            items = Model.itemList;
            currentItem = items.Find(item => item.itemID == tempItem.itemID);

            if (currentItem != null)
                currentItem.itemCount += count;
            else
                items.Add(tempItem);

            Model.item.Value = currentItem;
            Model.OnItemChange.Trigger();
        }
    }

    public class RemoveItemCommand : InventoryCommand
    {
        public RemoveItemCommand(Item item)
        {
            tempItem = item;
            count = tempItem.itemCount;
        }
        protected override void OnExecute()
        {
            Model = this.GetModel<InventoryModel>();
            items = Model.itemList;
            currentItem = items.Find(item => item.itemID == tempItem.itemID);

            if (currentItem != null)
            {
                currentItem.itemCount -= count;

                if (currentItem.itemCount <= 0)
                    items.Remove(currentItem);

                Model.item.Value = currentItem;
                Model.OnItemChange.Trigger();
            }
        }
    }
}