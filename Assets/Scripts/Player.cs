using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health = 10;
    public int currentHealth;
    public Healthbar healthbar;
    public Transform respawn;

    public GameObject[] gateDoor;
    public GameObject[] starImage;
    private int starsCollected = 0;

    public Cat cat;
    public GameObject finalMonster;

    public TextMeshProUGUI dialogue;
    public AudioClip dialogueAudio1, dialogueAudio2;

    //Sets health to full and updates the healthbar with the current health.
    //Sets the stars to be inactive.
    private void Start()
    {
        currentHealth = health;
        healthbar.SetHealth(currentHealth, health);

        foreach (var item in starImage)
        {
            if (item != null)
            {
                item.gameObject.SetActive(false);
            }
        }
    }

    //Reduces health by the damage amount and updates the healthbar.
    //If players health reaches 0, calls the respawn method.
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth, health);

            if (currentHealth <= 0 ) 
        {
            PlayerRespawn();
        }
    }

    //Transforms player position and resets the healthbar.
    public void PlayerRespawn()
    {
     
        Debug.Log("Respawn");
        this.gameObject.SetActive(false);
        transform.position = respawn.position;
        this.gameObject.SetActive(true);
        currentHealth = health;
        healthbar.SetHealth(currentHealth, health);

     
    }

    //When star is collected, actives the star image and opens the corrosponding gate by checking the ID.
    //When 3 stars are collected, activates text and audio.
    //When 4 stars are collected, activates text and audio, and makes the cat appear.
    public void StarPickup(int starID)
    {
        if (starsCollected < starImage.Length)
        {
            starImage[starsCollected].SetActive(true);
            starsCollected++;

            if (starID < gateDoor.Length && starID >= 0)
            {
                Gate gate = gateDoor[starID].GetComponent<Gate>();
                if (gate != null)
                {
                    gate.OpenGate();
                }
            }

            if(starsCollected == 3)
            {
                finalMonster.SetActive(true);
                dialogue.SendMessage("ShowText","Now your quest is nearing its end, on top of the hill is your final battle.");
                AudioSource.PlayClipAtPoint(dialogueAudio1, transform.position, 5.3f);
            }

            if (starsCollected == 4)
            {
                cat.catAppear();
                dialogue.SendMessage("ShowText", "Now the evil has been vanquished from here let light, peace, and love flow once more throughout these lands");
                AudioSource.PlayClipAtPoint(dialogueAudio2, transform.position, 5.3f);
            }
        }
    }
}
