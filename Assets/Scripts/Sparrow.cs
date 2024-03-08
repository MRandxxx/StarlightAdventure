using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparrow : MonoBehaviour
{
    private Animator sparrowAnimation;
    public AudioClip sparrowSound;

    void Start()
    {
       sparrowAnimation= GetComponent<Animator>();
    }

    //Play animation and sound when Sparrow is released.
    public void FreeSparrow()
    {
     sparrowAnimation.SetTrigger("Free");
        AudioSource.PlayClipAtPoint(sparrowSound, transform.position, 2.3f);
    }
}
