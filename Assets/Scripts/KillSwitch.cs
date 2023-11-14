using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KillSwitch : MonoBehaviour
{
    [SerializeField]GameObject triggerobj;
    bool played = false;
    AudioSource audioSource;
    [SerializeField] AudioClip shot;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!played && triggerobj.GetComponent<PressurePlate>().IsOn())
        {
           StartCoroutine(ending());
            played = true;
        }
    }

    public IEnumerator ending()
    {

        audioSource.PlayOneShot(shot, 1f);
        transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        Destroy(FindObjectOfType<AudioPlayer>().gameObject);
        yield return new WaitForSeconds(6.5F);
        SceneManager.LoadScene("GoodEnding");

    }

}
