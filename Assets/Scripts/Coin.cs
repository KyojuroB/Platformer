using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip coinSFX;
    [SerializeField] int ammountToAdd = 5;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool pk =false;
        if (!pk)
        {
            pk = true;
            FindObjectOfType<GameSession>().AddScore(ammountToAdd);
            AudioSource.PlayClipAtPoint(coinSFX, Camera.main.transform.position);
            Destroy(gameObject);

        }

    }
}
