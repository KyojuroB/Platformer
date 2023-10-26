using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    BoxCollider2D myCol;
    [SerializeField] float speed = 5.5f;
    bool isUp = false;
    // Start is called before the first frame update
    void Start()
    {
        myCol = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PickUp();
        ////////////////////
        if (isUp)
        {
            myCol.isTrigger = true;
            transform.position = GameObject.FindGameObjectWithTag("AttackRange").gameObject.transform.position;
           
            //transform.position = Vector2.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("AttackRange").gameObject.transform.position, speed);

        }
    }
    private void PickUp()
    {
        if (Input.GetKeyDown(KeyCode.E) && myCol.IsTouchingLayers(LayerMask.GetMask("AtackCollider")))
        {
        
            if (!isUp)
            {
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
