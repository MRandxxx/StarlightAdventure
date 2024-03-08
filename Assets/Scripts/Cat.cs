using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    private Animator catAnimation;
    public ParticleSystem fireFly;
    public AudioClip catSound;

    void Start()
    {
        transform.gameObject.SetActive(false);
        catAnimation = GetComponent<Animator>();
       
    }

    //Plays animation, sound, and firefly particle system when cat is released.
   public void catAppear()
    {
        transform.gameObject.SetActive(true);
        catAnimation.SetTrigger("Free");
        fireFly.Play();
        AudioSource.PlayClipAtPoint(catSound, transform.position, 2.3f);
    }
}
