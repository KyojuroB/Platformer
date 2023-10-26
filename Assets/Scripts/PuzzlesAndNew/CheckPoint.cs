using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] Sprite pointHitSprite;
    PolygonCollider2D polygonCollider;
    // Start is called before the first frame update
    void Start()
    {
        polygonCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (polygonCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            FindObjectOfType<GameSession>().SetCheckpoint(gameObject);
            GetComponent<SpriteRenderer>().sprite = pointHitSprite;
        }
    }
}
