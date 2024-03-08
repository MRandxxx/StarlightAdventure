using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{

    public int starID;
    public AudioClip starSound;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void starAppear()
    {
        gameObject.SetActive(true);
      
    }

    //When player walks into the star, star sound wil play, text will appear, and star will disapear.
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.SendMessage("StarPickup", starID);
            AudioSource.PlayClipAtPoint(starSound, transform.position, 0.3f);

            Destroy(gameObject);
        }
    }



}
