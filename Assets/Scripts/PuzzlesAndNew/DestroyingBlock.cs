using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestroyingBlock : MonoBehaviour
{
    [SerializeField] GameObject triggerobj;
    TilemapCollider2D mtc;
    Tilemap sr;
    // Start is called before the first frame update
    void Start()
    {
        mtc = GetComponent<TilemapCollider2D>();
        sr = GetComponent<Tilemap>();
    }



    // Update is called once per frame
    void Update()
    {

        if (triggerobj.GetComponent<PressurePlate>().IsOn())
        {
            mtc.enabled = false;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.3f);
        }
        if (!triggerobj.GetComponent<PressurePlate>().IsOn())
        {
            mtc.enabled = true;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);

        }

    }
}
