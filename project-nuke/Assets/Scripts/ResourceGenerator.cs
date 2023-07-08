using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class ResourceGenerator : MonoBehaviour
{

    public ResourceList resourceList;
    public Tilemap ground;

    public int x;


    [ContextMenu("GenerateXResources")]
    private void GenerateXResources()
    {
        GenerateResources(x);
    }

    private void GenerateResources(int amount)
    {
        List<TileBase> resourceTiles = resourceList.GetResourceTiles();
        List<Tilemap> resourceMaps = resourceList.GetResourceMaps();
        for (int i = 0; i < amount; i++)
        {
            int rand = Random.Range(0, resourceTiles.Count);
            TileBase resource = resourceTiles[rand];
            Tilemap map = resourceMaps[rand];
            Vector3 randLocation = ground.CellToWorld(new Vector3Int(
                ground.origin.x + Random.Range(0, ground.size.x),
                ground.origin.y + Random.Range(0, ground.size.y)
                ));
            map.SetTile(map.WorldToCell(randLocation), resource);
        }
    }

    [ContextMenu("ClearResources")]
    private void ClearAllResources()
    {
        foreach (Tilemap tilemap in resourceList.GetResourceMaps())
        {
            tilemap.ClearAllTiles();
        }
    }
}
