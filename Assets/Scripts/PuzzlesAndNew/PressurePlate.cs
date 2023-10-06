using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    bool isDown = false;
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
        if (triggerCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            Debug.Log("Touched");
            if (!isDown)
            {
                myanim.SetBool("isDown", true);
                isDown = true;
                new WaitForSeconds(3);
                return;
            }
            else
            {
                myanim.SetBool("isDown", false);
                isDown = false;
                new WaitForSeconds(3);
                return;
            }


         


        }

    }
}
