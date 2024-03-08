
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Introduction : MonoBehaviour
{
    public TextMeshProUGUI dialogue;
    public AudioClip[] dialogueAudio;
    private int currentDialogue = 0;
    private bool triggerDialogue = false;
    private bool endOfDialogue;


    //Triggers the text and audio based on the players input. 
    //Once the end of the text and audio has been reached, clears the text.
    private void Update()
    {
        if (Input.GetButtonDown("PickUp") && triggerDialogue)
        {
            if (!endOfDialogue)
            {

                if (currentDialogue < dialogueAudio.Length)
                {
                    PlayDialogue();
                    currentDialogue++;
                }

                else
                {
                    endOfDialogue = true;
                }
            }

            else
            {
                ClearDialogue();
            }
        }
    }

    //Method to trigger the text and speach when the player enters the collider.
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && !triggerDialogue)
        {
            triggerDialogue = true;
            currentDialogue = 0;
            endOfDialogue = false;
            PlayDialogue();
        }

    }

    //Sequence of text to be shown aswell as the audio.

    private void PlayDialogue()
    {
        switch (currentDialogue)
        {
            case 0:
                dialogue.SetText("Welcome to my home...");
                break;
            case 1:
                dialogue.SetText("Unfortunately, evil mushrooms are taking over. They captured my friends and locked them in cages.”");
                break;
            case 2:
                dialogue.SetText("Please help to free them and restore my home");
                break;
            case 3:
                dialogue.SetText("Infront of you is a magic sword, you will need this to defeat the evil mushrooms.Just walk towards it and you will gain its power.");
                break;
        }
        AudioSource.PlayClipAtPoint(dialogueAudio[currentDialogue], transform.position, 5.3f);
    }


    private void ClearDialogue()
    {
        dialogue.SetText("");
        endOfDialogue = false;
    }
}