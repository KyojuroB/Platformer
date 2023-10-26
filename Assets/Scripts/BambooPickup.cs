using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BambooPickup : MonoBehaviour
{
    PolygonCollider2D col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (col.IsTouchingLayers(LayerMask.GetMask("Player")))
        {


            Destroy(gameObject);
        }
    }
}
