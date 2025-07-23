using UnityEngine;

public class ClearItems : MonoBehaviour
{
    public void Clear()
    {
        InventoryManager.Instance.ClearItems();
    }
}
