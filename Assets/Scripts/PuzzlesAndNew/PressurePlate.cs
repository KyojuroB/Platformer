using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    bool isDown = false;
    bool istouching = false;
    Animator myanim;
    BoxCollider2D triggerCollider;
    [SerializeField] AudioClip switchNoise;
  
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
                AudioSource.PlayClipAtPoint(switchNoise, Camera.main.transform.position);
                myanim.SetBool("isDown", true);
                isDown = true;
                istouching = true;
                return;
            }
            else
            {
                AudioSource.PlayClipAtPoint(switchNoise, Camera.main.transform.position);
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
