using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] Sprite pointHitSprite;
    PolygonCollider2D polygonCollider;
    [SerializeField] AudioClip clip;
    AudioSource aS;
    bool hasReached = false;
    // Start is called before the first frame update
    void Start()
    {
        aS = GetComponent<AudioSource>();
        polygonCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (polygonCollider.IsTouchingLayers(LayerMask.GetMask("Player")) && !hasReached)
        {
            aS.PlayOneShot(clip);
            FindObjectOfType<GameSession>().SetCheckpoint(gameObject);
            GetComponent<SpriteRenderer>().sprite = pointHitSprite;
            hasReached = true;
        }
    }
}
