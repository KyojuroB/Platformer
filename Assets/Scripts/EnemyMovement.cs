using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed = 5;
    Animator animator;
    Rigidbody2D rb;
    CircleCollider2D circleCollider;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveRight();
        Animation();
        ///////////////
        if (circleCollider.IsTouchingLayers(LayerMask.GetMask("AtackCollider")) && Input.GetKey(KeyCode.Mouse0))
        { 
            Destroy(gameObject);
        }
    }

    void MoveRight()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
    void Animation()
    {
        bool ismoving = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        animator.SetBool("IsMoving", ismoving);
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       speed = -speed;
        FlipEnemyFacing();
    }
    void FlipEnemyFacing()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), 1f);
    }
    
}
