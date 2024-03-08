using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public enum MenuOptions
    {
        StartGame,
        QuitGame,
        DisplayInstructions,
        None
    }
    public MenuOptions options;
    public MenuOptions currentOption;
    public TextMeshProUGUI hints;
    public GameObject instructions;
    public ParticleSystem fireFly;

    // Hide hints and instructions when game starts.
    private void Start()
    {
        if (hints != null)
            hints.gameObject.SetActive(false);
        if (instructions != null)
            instructions.gameObject.SetActive(false);
        
    }

    //Preforms the action based on which menu option has been clicked.
    private void Update()
    {
       if( hints != null && hints.gameObject.activeSelf && Input.GetButtonDown("PickUp"))
        {
            PerformMenuAction();
        }
                }

    //When the player enters the trigger zone, shows the hint, shows firefly particles and sets the menu option.
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            currentOption = options;
            if (hints != null)
            {
                hints.gameObject.SetActive(true);
                     ;
            }

            if (fireFly != null)
                fireFly.Play();

        }
    }

    //When player exits the trigger zone, resets the menu option, removes the hint and firefly particle system.
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            currentOption = MenuOptions.None;
            if (hints != null)
            {
                hints.gameObject.SetActive(false);
            }
            if (fireFly != null)
                fireFly.Stop();
            fireFly.Clear();
        }
    }


    void PerformMenuAction()
    {
        switch(currentOption)
        {
            case MenuOptions.StartGame:
                    StartGame();
                break;

            case MenuOptions.QuitGame:
                    QuitGame();
                break;

            case MenuOptions.DisplayInstructions:
                    DisplayInstructions();
                break;
        }
    }

    void StartGame()
    {
        SceneManager.LoadScene("Island");
    }

    void QuitGame()
    {
        Application.Quit();
    }
   

    public void DisplayInstructions()
    {
        if (instructions != null)
        {
            bool instructionsDisplayed= instructions.activeSelf;
            instructions.SetActive(!instructionsDisplayed);
        }
    }



}
