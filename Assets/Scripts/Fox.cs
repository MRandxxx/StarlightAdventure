using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{

    private Animator foxAnimation;
    public AudioClip foxSound;

    void Start()
    {
        foxAnimation = GetComponent<Animator>();
    }

    //Play animation and sound when fox is released.
    public void FreeFox()
    {
        foxAnimation.SetTrigger("Free");
        AudioSource.PlayClipAtPoint(foxSound, transform.position, 2.3f);

    }

}
