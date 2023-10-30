using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureCubePlate : MonoBehaviour
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
        if (triggerCollider.IsTouchingLayers(LayerMask.GetMask("CubePickUp")) && istouching == false)
        {

            if (!isDown)
            {
                myanim.SetBool("isOff", true);
                isDown = true;
                istouching = true;
                return;
            }

        }
        if (triggerCollider.IsTouchingLayers(LayerMask.GetMask("CubePickUp")) == false)
        {
            myanim.SetBool("isOff", false);
            isDown = false;
            istouching = false;
        }
    }
    public bool IsOn()
    {
        return isDown;
    }
}
