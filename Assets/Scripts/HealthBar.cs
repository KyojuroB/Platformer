using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<GameSession>().GetHealth() > transform.childCount)
        {
            Destroy(transform.GetChild(0));
        }
    }
}
