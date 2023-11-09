using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestroyingBlock : MonoBehaviour
{
    [SerializeField] GameObject triggerobj;
    TilemapCollider2D mtc;
    Tilemap sr;
    [SerializeField] bool isBlock = false;
    [SerializeField] bool isNegative;
    // Start is called before the first frame update
    void Start()
    {
        mtc = GetComponent<TilemapCollider2D>();
        sr = GetComponent<Tilemap>();
    }



    // Update is called once per frame
    void Update()
    {
        if (!isNegative)
        { 
                    if (isBlock == false && triggerobj != null )
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

            //////////////////////////////////////////////////////////////////////////////////////
        
            if (isBlock == true && triggerobj != null)
            { 
                if (triggerobj.GetComponent<PressureCubePlate>().IsOn())
                {
                    mtc.enabled = false;
                    sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.3f);
                }
                if (!triggerobj.GetComponent<PressureCubePlate>().IsOn())
                {
                    mtc.enabled = true;
                    sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
                }
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if(isNegative)
        {
            if (isBlock == false && triggerobj != null)
            {
                if (triggerobj.GetComponent<PressurePlate>().IsOn())
                {
                    mtc.enabled = true;
                    sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);


                }
                if (!triggerobj.GetComponent<PressurePlate>().IsOn())
                {
                    mtc.enabled = false;
                    sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.3f);
                }
            }

            //////////////////////////////////////////////////////////////////////////////////////

            if (isBlock == true && triggerobj != null)
            {
                if (triggerobj.GetComponent<PressureCubePlate>().IsOn())
                {
                    mtc.enabled = true;
                    sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
                }
                if (!triggerobj.GetComponent<PressureCubePlate>().IsOn())
                {
                    mtc.enabled = false;
                    sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.3f);

                }
            }

        }

    }

}
