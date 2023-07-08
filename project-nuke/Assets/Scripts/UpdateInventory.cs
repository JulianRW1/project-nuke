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

    public Dictionary<string, TextMeshProUGUI> textFieldMap;

    // Start is called before the first frame update
    void Start()
    {
        textFieldMap = new Dictionary<string, TextMeshProUGUI>();
        for (int i = 0; i < resourceNames.Count; i++)
        {
            TextMeshProUGUI text = resourceQuantityTexts[i].GetComponent<TextMeshProUGUI>();
            textFieldMap[resourceNames[i]] = text;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < resourceNames.Count;i++)
        {
            string resource = resourceNames[i];
            Debug.Log("resource quantity: " + inventory.getResourceQuantity(resource).ToString());
            Debug.Log("text mesh pro" + resourceQuantityTexts[i].GetComponent<TextMeshProUGUI>().name);
            textFieldMap[resource].SetText(inventory.getResourceQuantity(resource).ToString());
        }
    }
}
