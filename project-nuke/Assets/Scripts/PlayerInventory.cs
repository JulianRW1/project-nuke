using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class PlayerInventory : ScriptableObject
{
    private Dictionary<string, int> inventory = new Dictionary<string, int>
    {
        { "wood", 0}, {"stone", 0}
    };

    public int getResourceQuantity(string resource)
    {
        if (inventory.ContainsKey(getResourceName(resource))) {
            return inventory[getResourceName(resource)];
        } else {
            Debug.Log("invalid resource key: " + resource);
            return -1;
        }
    }

    public void AddResource(string resource)
    {
        if (inventory.ContainsKey(getResourceName(resource)))
        {

            inventory[getResourceName(resource)]++;
        } else
        {
            Debug.Log("invalid resource key: " + resource);
        }
    }
    public void RemoveResource(string resource)
    {
        if (inventory.ContainsKey(getResourceName(resource)))
        {
            inventory[getResourceName(resource)]--;
        }
        else
        {
            Debug.Log("invalid resource key: " + resource);
        }
    }

    public int getResourceQuantity(TileBase resource)
    {
        return getResourceQuantity(getResourceName(resource));
    }

    public void AddResource(TileBase resource)
    {
        AddResource(getResourceName(resource));
    }
    public void RemoveResource(TileBase resource)
    {
        RemoveResource(getResourceName(resource));
    }
    private string getResourceName(TileBase resource)
    {
        return resource.name.Substring(0, resource.name.Length - 4).ToLower();
    }

    private string getResourceName(string resource)
    {
        return resource.ToLower();
    }
}
