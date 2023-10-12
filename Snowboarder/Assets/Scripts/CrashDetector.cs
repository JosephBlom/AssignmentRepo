using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadTime = 1.5f;
    [SerializeField] ParticleSystem crash;
    [SerializeField] AudioClip crashSFX;
    bool crashed = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground" && crashed == true)
        {
            crashed = false;
            FindObjectOfType<PlayerController>().DisableControls();
            crash.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", loadTime);
            
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene("Level 1");
    }
}
