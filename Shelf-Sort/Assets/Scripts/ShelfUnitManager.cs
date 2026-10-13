using UnityEngine;
using System;

public class ShelfUnitManager : MonoBehaviour
{
    private GameObject[] shelfSlots = new GameObject[3];


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < shelfSlots.Length ; i++)
        {
            shelfSlots[i] = transform.GetChild(i).gameObject;
        }
    }

    public void CheckMatch()
    {
        bool allNotNull = Array.TrueForAll(shelfSlots, slot => slot != null);
        // if shelf is full and items are of the same type
        // TODO: write method to get type of the item stored in the ShelfSlot, not the shelfslot object's type
        if (allNotNull && shelfSlots[0].GetType() == shelfSlots[1].GetType() && shelfSlots[1].GetType() == shelfSlots[2].GetType())
        {
            // TODO: Add point

            // Destroy all items in the shelf unit
            foreach (var item in shelfSlots)
            {
                Destroy(item);
            }

        }
    }
}
