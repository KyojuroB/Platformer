using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float JumpSpeed = 15;
    [SerializeField] float runSpeed = 6.5f;
    [SerializeField] float ladderSpeed = 10f;
    [SerializeField] AudioClip jumpNoise;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D bodyCollider;
    BoxCollider2D myFeetCollider;
    float gravitScaleAtStart;
    bool isAlive = true;
    AudioSource aS;
    [SerializeField] AudioClip bounce;
    bool off = true;
    [SerializeField] float maxSpeed = 10f;

    public void HitEnemy()
    {
        myAnimator.SetTrigger("hasHit");
    }
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        bodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        gravitScaleAtStart = myRigidbody.gravityScale;
        aS = GetComponent<AudioSource>();

    }

    private void FixedUpdate()
    {
      //  myRigidbody.velocity = Vector3.ClampMagnitude(myRigidbody.velocity, maxSpeed);
    }

    void Update()
    {
        
        if (myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Bouncing")) && off)
        {
            off = false; 

            
            AudioSource.PlayClipAtPoint(bounce, Camera.main.transform.position);
        }

        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Bouncing")) && !off)
        {
            
            off = true;
        }


        if (myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Speed")) )
        {
            runSpeed = 11f;

           
        }

        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Speed")))
        {

            runSpeed = 6.5f;
        }

        if (!isAlive)
        {
            return;
        }
        Run();
        FlipSpirte();
        ClimbLadder();
        Die();
        
    }

    void OnMove(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }
        moveInput = value.Get<Vector2>();
       // Debug.Log(moveInput);
    }

    void OnJump(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }

        if (myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground", "CubePickUp", "Speed")) == false)
        {
            return;
        }
        if (value.isPressed)
        {
         
            AudioSource.PlayClipAtPoint(jumpNoise, Camera.main.transform.position, 0.43f);
            myRigidbody.velocity += new Vector2(0, JumpSpeed);
        }
    }

    void ClimbLadder()
    {
        if (bodyCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")) == false)
        {
            myAnimator.SetBool("isClimbing", false);
            myRigidbody.gravityScale = gravitScaleAtStart;
            return;
        }
            myRigidbody.gravityScale = 0;
            Vector2 laderVelocity = new Vector2(myRigidbody.velocity.x, moveInput.y * ladderSpeed);
            myRigidbody.velocity = laderVelocity;
            bool playerHasSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
            myAnimator.SetBool("isClimbing", playerHasSpeed);
              
    }

    void Run()
    {
        Vector2 playervelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playervelocity;
        bool playerHasHorizontaSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHasHorizontaSpeed);
        if (!aS.isPlaying && playerHasHorizontaSpeed && myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground", "CubePickUp")))
        {
            aS.Play();
        }
        else if (aS.isPlaying && !playerHasHorizontaSpeed || !myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground", "CubePickUp")))
        {
            aS.Stop();
        }
            


    }

    void FlipSpirte()
    {
        bool playerHasHorizontaSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        
        if (playerHasHorizontaSpeed == true)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x)  * 1.5f, 1.5f);
        }

    }
    private void Die()
    {
        if (myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards", "Water", "Projectile")) || bodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards", "Water", "Projectile")))
        {


            StartCoroutine(Dying());
        }
    }
    private IEnumerator Dying()
    {
       
        isAlive = false;
        myAnimator.SetTrigger("isDead");
        myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y);
        yield return new WaitForSeconds(0.45f);
        FindObjectOfType<GameSession>().DoDamage();




    }

}


