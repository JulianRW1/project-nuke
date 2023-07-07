using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ResourceScript : MonoBehaviour
{
    public TileBase wood;
    public TileBase stone;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.Equals(wood))
        {
            Debug.Log("wood");
        } else if (collision.gameObject.Equals(stone))
        {
            Debug.Log("stone");
        }
    }
}
