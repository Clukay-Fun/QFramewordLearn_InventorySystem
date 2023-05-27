using QFramework;
using System.Collections.Generic;

namespace QFramework.Inventory
{
    public class InventoryModel : AbstractModel, IModel
    {
        /// <summary>
        /// �洢��Ʒ�Ŀɰ�����
        /// </summary>
        public BindableProperty<Item> item = new BindableProperty<Item>();

        /// <summary>
        /// �洢������Ʒ���б�
        /// </summary>
        public List<Item> itemList = new List<Item>();

        /// <summary>
        /// ����Ʒ�����仯ʱ�������¼�
        /// </summary>
        public EasyEvent OnItemChange = new EasyEvent();

        protected override void OnInit()
        {
            var storage = this.GetUtility<IStorage>();

            // �ӳ־û������м�����Ʒ�б�
            if (storage.LoadData<List<Item>>("InventoryData") != null)
                itemList = storage.LoadData<List<Item>>("InventoryData");

            // ������Ʒ���ʱ��������Ʒ�б��־û�������
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
