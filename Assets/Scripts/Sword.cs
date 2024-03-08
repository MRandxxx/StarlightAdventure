using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Animator swordAnimation;
    public Transform swordView;
    public GameObject swordPrefab;
    public AudioClip swordSound;
    public AudioClip pickUpSound;
    private bool swordAttacking = false;
    public float attack = 2f;
    public LayerMask monsterLayer;
    public TextMeshProUGUI dialogue;
    public AudioClip dialogueAudio;



    private void Start()
    {
        
    }

    //When player left clicks, calls the sword attack. 
    void Update()
    {

            if (Input.GetButtonDown("Fire1"))
            {
            SwordAttack();
            }
        }

    //When player picks up the sword, sets the sword to the sword veiw game object and sets its position.
    //Enables animation, sound, and shows text.
    void PickUp()
    {
        swordAnimation = GetComponent<Animator>();

        transform.SetParent(swordView);
        transform.position = swordView.position;
        transform.rotation = swordView.rotation;
        swordPrefab.transform.localPosition = Vector3.zero;
        swordPrefab.transform.localScale = Vector3.one;

        swordAnimation.enabled = true;
        GetComponent<Collider>().enabled = false;
        dialogue.SendMessage("ShowText", "Now explore the island and complete your quest ");
        AudioSource.PlayClipAtPoint(dialogueAudio, transform.position, 3.3f);

    }
      
    //When player enters the trigger, calls the pickup() and plays audio.
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            PickUp();
            AudioSource.PlayClipAtPoint(pickUpSound, transform.position, 2.3f);

        }
    }
    //Sword attack.
    //Plays animation and sound.
    //Perform raycast and check if a monster is hit. If monster is hit, reducts 1 from their health.
    public void SwordAttack()
    {
       
        swordAttacking = true;
        swordAnimation.SetTrigger("Swing");
        AudioSource.PlayClipAtPoint(swordSound, transform.position, 0.3f);

        RaycastHit hit;
        Vector3 start = transform.position;
        Vector3 direction = transform.forward;

       

        if (Physics.Raycast(start, direction, out hit, attack, monsterLayer))
        {
            if (hit.collider.tag == "MonsterBody")
                    {
                        Monster monster = hit.collider.GetComponent<Monster>();
                if (monster != null)
                {
                    monster.DamageToHealth(1);
                }
                    }
        }

    }

    public void EndSwordAttack()
    {
        swordAttacking = false;

    }


}
