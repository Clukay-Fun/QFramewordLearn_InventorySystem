using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Inventory
{
	// Generate Id:bd6ad4a4-9b8f-4a50-a528-3534ad4449d5
	public partial class InventoryPanel
	{
		public const string Name = "InventoryPanel";
		
		[SerializeField]
		public RectTransform Content;
		
		private InventoryPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			Content = null;
			mData = null;
		}
		
		public InventoryPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		InventoryPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new InventoryPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
