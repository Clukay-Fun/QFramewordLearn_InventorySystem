using UnityEngine;
using UnityEngine.UI;
using QFramework;
using System.Collections.Generic;

namespace QFramework.Inventory
{
	public class InventoryPanelData : UIPanelData
	{
        public GameObject itemGrid;
        public List<Item> itemList;
    }
	public partial class InventoryPanel : UIPanel
	{
        private ResLoader mResLoader = ResLoader.Allocate();

        protected override void OnInit(IUIData uiData = null)
		{
            mData = uiData as InventoryPanelData ?? new InventoryPanelData();

            // please add init code here
            InventoryModel model;
            model = InventoryArchitecture.Interface.GetModel<InventoryModel>();

            mData.itemList = model.itemList;

			model.OnItemChange.Register(UpdateItemGrid).UnRegisterWhenGameObjectDestroyed(gameObject);

		}

		protected override void OnOpen(IUIData uiData = null)
		{
			
		}

		protected override void OnShow()
		{
			UpdateItemGrid();
        }

		protected override void OnHide()
		{
            for (int i = Content.childCount - 1; i >= 0; i--)
			{
				Destroy(Content.GetChild(i).gameObject);
			}
		}

		protected override void OnClose()
		{
		}

        private void UpdateItemGrid()
		{
			if (mData.itemList == null) return;

            mData.itemGrid = mResLoader.LoadSync<GameObject>("ItemGrid");
			ItemGrid itemGrid;
			for (int i = Content.childCount - 1; i >= 0; i--)
            {
                Destroy(Content.GetChild(i).gameObject);
            }
            for (int i = 0; i < mData.itemList.Count; i++)
            {
                itemGrid = Instantiate(mData.itemGrid, Content).GetComponent<ItemGrid>();
				itemGrid.ItemCount.text = mData.itemList[i].itemCount.ToString();
				itemGrid.data = mData.itemList[i];
            }
		}
    }
}
