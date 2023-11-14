using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public float fireRate = 1f;
    public GameObject fireballPrefab;
    public float pading = 1f;
    Vector2 pos;
    public AudioClip shot;
    AudioSource audioSource;
    BoxCollider2D boxCollider;
    bool hasTriggered = false;
  
    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        pos = new Vector2(gameObject.transform.position.x + pading, gameObject.transform.position.y);
        
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (!hasTriggered && boxCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {

            StartCoroutine(FireProjectile());
            hasTriggered = true;
        }
            
        
            
    }
    private IEnumerator FireProjectile()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);

            
            GameObject fireball = Instantiate(fireballPrefab, pos, Quaternion.identity);

            
            fireball.GetComponent<Rigidbody2D>().velocity = Vector2.down * Random.Range(1, 6);
            fireball.GetComponent<Rigidbody2D>().velocity = Vector2.right * Random.Range(1,6);

            audioSource.PlayOneShot(shot, 0.05f);


            Destroy(fireball, 3f);
        }
    }
}
