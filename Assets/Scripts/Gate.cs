using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    
    public int gateID;
    private Animator gateAnimation;
    public Fox foxAnimation;
    public Rabbit rabbitAnimation;
    public Sparrow sparrowAnimation;


    //Disable animation at start of the game.
    private void Start()
    {
        gateAnimation = GetComponent<Animator>();
        gateAnimation.enabled = false;
    }

    //Method to open the gate. Checks the value of the gateID to determine which animal to free. Triggers the correct animation.
        public void OpenGate()
    {
            gateAnimation.enabled = true;
            gateAnimation.SetTrigger("Open");

        if (gateID == 0)
        {
            foxAnimation.FreeFox();
        }

        else if (gateID == 1)
        {
            sparrowAnimation.FreeSparrow();
        }
        else if (gateID == 2)
        { 
            rabbitAnimation.FreeRabbit();
        }
        
    }
    
}
