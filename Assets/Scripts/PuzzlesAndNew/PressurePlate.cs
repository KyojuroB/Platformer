using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    bool isDown = false;
    bool istouching = false;
    Animator myanim;
    BoxCollider2D triggerCollider;
  
    void Start()
    {
        triggerCollider = GetComponent<BoxCollider2D>();
        myanim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerCollider.IsTouchingLayers(LayerMask.GetMask("Player")) && istouching==false)
        {
            
            if (!isDown)
            {
                myanim.SetBool("isDown", true);
                isDown = true;
                istouching = true;
                return;
            }
            else
            {
                myanim.SetBool("isDown", false);
                isDown = false;
                istouching = true;
                return;
            }
        }
        if (triggerCollider.IsTouchingLayers(LayerMask.GetMask("Player")) == false)
        {
            istouching = false;
        }
    }
    public bool IsOn()
    {
        return isDown;
    }

}
