using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour
{
    private Animator rabbitAnimation;
    public AudioClip rabbitSound;

    void Start()
    {
       rabbitAnimation = GetComponent<Animator>();
    }

    //Play sound and animation when Rabbit is released.
    public void FreeRabbit()
    {
        rabbitAnimation.SetTrigger("Free");
        AudioSource.PlayClipAtPoint(rabbitSound, transform.position, 2.3f);
    }

}
