using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class UpdateInventory : MonoBehaviour
{
    public PlayerInventory inventory;

    public List<string> resourceNames;
    public List<GameObject> resourceQuantityTexts;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < resourceNames.Count;i++)
        {
            string resource = resourceNames[i];
            resourceQuantityTexts[i].GetComponent<TextMeshProUGUI>().SetText(inventory.getResourceQuantity(resource).ToString());
        }
    }
}
