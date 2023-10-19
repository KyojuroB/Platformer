using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    int current = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void remove()
    {
        Debug.Log("Kill");
        transform.GetChild(current).gameObject.SetActive(false);
        current++;
    }
    public void Re()
    {
        current = 0;
        for (int i = 0; i > transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

}
