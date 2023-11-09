using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureCubePlate : MonoBehaviour
{
    bool isDown = false;
    bool istouching = false;
    Animator myanim;
    BoxCollider2D triggerCollider;
    AudioSource myAudioSource;
    [SerializeField] AudioClip myclip;
    bool previousState = false;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        triggerCollider = GetComponent<BoxCollider2D>();
        myanim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool currentState = triggerCollider.IsTouchingLayers(LayerMask.GetMask("CubePickUp"));

        if (currentState && !previousState)
        {
            // Box is placed on the pressure plate
            myAudioSource.PlayOneShot(myclip);
            myanim.SetBool("isOff", true);
            isDown = true;
        }
        else if (!currentState && previousState)
        {
            // Box is lifted off the pressure plate
            myAudioSource.PlayOneShot(myclip);
            myanim.SetBool("isOff", false);
            isDown = false;
        }

        istouching = currentState;
        previousState = currentState;
    }

    public bool IsOn()
    {
        return isDown;
    }
}

