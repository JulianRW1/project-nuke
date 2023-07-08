using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class ResourceList : ScriptableObject
{
    public List<TileBase> resourceTiles;

    private GameObject[] resourceMapObjects;


    public List<Tilemap> GetResourceMaps()
    {
        resourceMapObjects = GameObject.FindGameObjectsWithTag("ResourceMap");
        List<Tilemap> resourceMaps = new List<Tilemap>();
        foreach (GameObject o in resourceMapObjects)
        {
            resourceMaps.Add(o.GetComponent<Tilemap>());
        }
        return resourceMaps;
    }

    public List<TileBase> GetResourceTiles()
    {
        return resourceTiles;
    }


    
}
