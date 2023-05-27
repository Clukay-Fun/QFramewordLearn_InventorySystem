using QFramework;
using UnityEngine;

namespace QFramework.Inventory
{
    public interface IStorage : IUtility
    {
        void SaveData(object data, string fileName);
        T LoadData<T>(string fileName) where T : new();
    }

    public class InventoryStorage : IStorage
    {
        public void SaveData(object data, string fileName)
        {
            JsonManager.SaveData(data, fileName);
        }
        public T LoadData<T>(string fileName) where T : new()
        {
            return JsonManager.LoadData<T>(fileName);
        }
    }
}
