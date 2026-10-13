using UnityEngine;

public class ShelfSlotManager : MonoBehaviour
{
    GameObject item = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        item = collider.gameObject;
    }

    private void OnTriggerExit(Collider collider)
    {
        item = null;
    }

    public bool IsEmpty()
    {
        return item == null;
    }
}
