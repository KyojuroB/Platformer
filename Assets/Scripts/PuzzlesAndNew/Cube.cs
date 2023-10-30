using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    BoxCollider2D myCol;
   public bool isUp = false;

    void Start()
    {
        myCol = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PickUp();
       
        if (isUp)
        {
           
            transform.position = GameObject.FindGameObjectWithTag("AttackRange").gameObject.transform.position;
           
         

        }
    }
    private void PickUp()
    {
        if (Input.GetKeyDown(KeyCode.E) && myCol.IsTouchingLayers(LayerMask.GetMask("AtackCollider")))
        {
        
            if (!isUp)
            {
                myCol.isTrigger = true;
                isUp = true;
                
            }
            else if (isUp)
            {
                myCol.isTrigger = false;
                isUp = false;
            }
                
                    
                

        }
        
    }
}
