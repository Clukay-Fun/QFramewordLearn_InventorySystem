using UnityEngine;

namespace QFramework.Inventory
{
    public class GameManager : MonoBehaviour
    {

        void Awake()
        {
            new GameObject("InventoryController").AddComponent<InventoryController>();
        }

    }
}
