using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SecretBlocks : MonoBehaviour
{
    TilemapCollider2D myCollider;
    Tilemap tm;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<TilemapCollider2D>();
        tm = GetComponent<Tilemap>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {

            tm.color = new Color(tm.color.r, tm.color.g, tm.color.b, 0.35f);
        }
        else 
        {
            tm.color = new Color(tm.color.r, tm.color.g, tm.color.b, 1f);
        }
    }
}
