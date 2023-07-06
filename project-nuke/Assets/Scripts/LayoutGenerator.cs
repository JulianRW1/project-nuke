using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.WSA;
using Random = UnityEngine.Random;

public class LayoutGenerator : MonoBehaviour
{
    public Tilemap map;
    public TileBase grassTile;
    public TileBase stoneTile;
    public TileBase waterTile;

    public List<TileBase> tileTypes;
    public List<int> tileFrequencies;

    public int chanceOfNewTile;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [ContextMenu("GenerateNewMap")]
    private void GenerateNewMap()
    {
        Vector3Int bottomLeft = map.origin;
        Vector3Int topRight = map.origin + map.size;

        for (int x = bottomLeft.x; x < topRight.x; x++) {
            for (int y = bottomLeft.y; y < topRight.y; y++)
            {
                List<TileBase> surroundingTiles = new List<TileBase>();
                if (x - 1 >= bottomLeft.x)
                {
                    surroundingTiles.Add(map.GetTile(new Vector3Int(x - 1, y)));
                } 
                if (y - 1 >= bottomLeft.y)
                {
                    surroundingTiles.Add(map.GetTile(new Vector3Int(x, y - 1)));
                }

                TileBase tile;
                if (surroundingTiles.Count == 0 || Random.Range(0, 100) < chanceOfNewTile)
                {
                    //place a new tile
                    tile = GenerateNewTile();
                } else
                {
                    // place an existing tile
                    tile = surroundingTiles[Random.Range(0, surroundingTiles.Count)];
                }

                map.SetTile(new Vector3Int(x, y), tile);
            }
        }
    }

    private TileBase GenerateNewTile()
    {

        int sum = 0;
        foreach (int freq in tileFrequencies) {
            sum += freq;
        }

        int randNum = Random.Range(0, sum);

        int tempSum = 0;
        for (int i = 0; i < tileFrequencies.Count; i++)
        {
            int freq = tileFrequencies[i];
            if (tempSum + freq < randNum)
            {
                tempSum += freq;
            }
            else
            {
                return tileTypes[i];
            }
        }
        Debug.Log("error! should not have reached this code in method GenerateNewTile in LayoutGenerator.cs");
        //TileBase tile = tileTypes[Random.Range(0, tileTypes.Count)];
        return null;
    }
}
