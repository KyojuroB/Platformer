using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class HealthBar : MonoBehaviour
{
    int current = 0;
    [SerializeField] GameObject heart;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //for (int i = 0; i > FindObjectOfType<GameSession>().GetHealth(); i++)
        //{
        //    transform.GetChild(i).gameObject.SetActive(false);
        //}
        //for (int i = 0; i < FindObjectOfType<GameSession>().GetHealth(); i++)
        //{
        //    transform.GetChild(i).gameObject.SetActive(true);
        //}

        if (FindObjectOfType<GameSession>().GetHealth() > transform.childCount)
        {

            Instantiate(heart, this.transform);

        }
        else if (FindObjectOfType<GameSession>().GetHealth() < transform.childCount)
        {

            Destroy(transform.GetChild(0).gameObject);

        }
    }


}
