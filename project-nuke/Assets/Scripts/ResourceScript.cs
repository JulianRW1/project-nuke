using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ResourceScript : MonoBehaviour
{
    public TileBase resourceType;
    public PlayerInventory playerInventory;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.Equals(player))
        {
            Tilemap map = this.gameObject.GetComponent<Tilemap>();
            Vector3Int tileOfPlayer = map.WorldToCell(player.transform.position);
            if (map.GetTile(tileOfPlayer) != null) {
                playerInventory.AddResource(resourceType);
                map.SetTile(tileOfPlayer, null);
            }
        } else
        {
            Debug.Log("unknown collision");
        }
    }
}
