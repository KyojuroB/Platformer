using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyingBlock : MonoBehaviour
{
    [SerializeField] GameObject triggerobj;
    BoxCollider2D myCollider;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }



    // Update is called once per frame
    void Update()
    {

        if (triggerobj.GetComponent<PressurePlate>().IsOn())
        {
            myCollider.enabled = false;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);
        }
        if (!triggerobj.GetComponent<PressurePlate>().IsOn())
        {
            myCollider.enabled = true;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);

        }

    }
}
