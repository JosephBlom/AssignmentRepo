using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishLine : MonoBehaviour
{
    [SerializeField] float loadTime = 1f;
    [SerializeField] ParticleSystem finishEffect;
    bool won = true;

   void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && won == true)
        {
            won = false;
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", loadTime);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
