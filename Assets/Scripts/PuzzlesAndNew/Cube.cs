using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    BoxCollider2D myCol;
   public bool isUp = false;
    [SerializeField] float padding = 1f;
    public bool istouchingcol = false;
    void Start()
    {
        myCol = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PickUp();

        if (myCol.IsTouchingLayers(LayerMask.GetMask("AtackCollider")))
        {
            istouchingcol = true;
        }
        else
        { 
            istouchingcol=false;
        }
        
        
        if (isUp)
        {

            transform.position = new Vector2(GameObject.FindGameObjectWithTag("AttackRange").gameObject.transform.position.x , GameObject.FindGameObjectWithTag("AttackRange").gameObject.transform.position.y);



        }
    }
    private void PickUp()
    {
        if (Input.GetKeyDown(KeyCode.E) && myCol.IsTouchingLayers(LayerMask.GetMask("AtackCollider")))
        {
            
        
            if (!isUp)
            {
             
                myCol.isTrigger = true;
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                isUp = true;
                
            }
            else 
            {
                myCol.isTrigger = false;
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                isUp = false;
            }
                
                    
                

        }     
    }
}
