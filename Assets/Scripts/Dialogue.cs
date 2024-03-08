using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour

{
    //Displays message.
        void ShowText(string message)
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = message;
            if (!gameObject.GetComponent<TextMeshProUGUI>().enabled)
            {
                gameObject.GetComponent<TextMeshProUGUI>().enabled = true;
            }
       
    }

    }




