using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    [SerializeField]float speed = 3.5f;
    Vector2 downPos;
    Vector2 upPos;
    PolygonCollider2D topCollider;
    [SerializeField] GameObject point1;
    [SerializeField] GameObject point2;
    [SerializeField] float waitTime = 3;
    [SerializeField] bool ups = false;
    bool followtr = false;

    
    void Start()
    {
        downPos = new Vector2(point1.transform.position.x, point1.transform.position.y);
        upPos = new Vector2(point2.transform.position.x, point2.transform.position.y);
        topCollider = GetComponent<PolygonCollider2D>();


    }
    void Update()
    {
        moving();
    }

    void moving()
    {
        if (!ups)
        {
            if (transform.position == point2.transform.position)
            {
                ups = true;
            }
            transform.localPosition = Vector2.MoveTowards(transform.position, upPos, speed * Time.deltaTime);
     
        }
        if ( ups)
        {
            if (transform.position == point1.transform.position)
            {
                ups = false;
            }
            transform.localPosition = Vector2.MoveTowards(transform.position, downPos, speed * Time.deltaTime);

        }
       

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {

          FindObjectOfType<PlayerMovement>().gameObject.transform.parent = gameObject.transform;
            
           Debug.Log("Collision");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {

            FindObjectOfType<PlayerMovement>().gameObject.transform.parent = null;
            Debug.Log("exitCollision");
        }

    }





}
