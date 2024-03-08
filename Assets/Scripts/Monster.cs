using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Monster : MonoBehaviour {

	public Player player;
	public int attack = 2;
	private bool hasColliderBeenTriggered = false;
	public int health = 10;
	public float runSpeed = 2.0f;
	public GameObject star;
	public AudioClip winSound;
	public TextMeshProUGUI dialogue;
	public AudioClip dialogueAudio;

	Animation anim;
	public const string IDLE	= "Idle";
	public const string RUN		= "Run";
	public const string ATTACK	= "Attack";
	public const string DAMAGE	= "Damage";
	public const string DEATH	= "Death";


	void Start () {
		anim = GetComponent<Animation>();
	}

	//Checks is the player has triggered the collider.
	//If player is close enough, attack player. If not, run towards player.
	//If collider has not been triggered, play idle animation/
	void Update()
	{
		if (hasColliderBeenTriggered)
        {
			float playerDistance = Vector3.Distance(player.transform.position, transform.position);
			
			if(playerDistance < 2f)
            {
				Attack();
            }
            else
            {
				RunTowardsPlayer();
            }
		}
        else
        {
			IdleAni();
        } 
	}

	//Monster runs towards player by facing the player and moving towards the players position.
	//Play the run animayion.
	private void RunTowardsPlayer()
    {
		transform.LookAt(player.transform.position);
		transform.position = Vector3.MoveTowards(transform.position, player.transform.position, runSpeed * Time.deltaTime);
		RunAni();
    }

	//Applys damage to the monster. Subtracks damage from the health and plays the damage animation.
	//Once health reaches 0, plays death animation and audio and triggers the dialogue.
	//Triggers star to appear upon death and removes the monster from the scene.
	public void DamageToHealth(int damage)
    {
		health -= damage;
		DamageAni();
		

		if (health <= 0)
        {
			DeathAni();
			AudioSource.PlayClipAtPoint(winSound, transform.position, 2.3f);
			Dialogue();

			if (star != null)
			{
				
				Star starObject = star.GetComponent<Star>();
				if (starObject != null)
				{
					starObject.starAppear();
					
				}
			}

			Destroy(this.gameObject);
        }
    }


	public void Attack()
	{
		AttackAni();
	}

	//Applies damage to the player.
	public void AttackDamage()
    {
		if (hasColliderBeenTriggered)
        {
			player.TakeDamage(attack);
        }
    }


	//Checks if the player has triggered the collider.
	private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
			hasColliderBeenTriggered = true;
			player = col.gameObject.GetComponent<Player>();
        }
    }

	//Sets text and audio when dialogue method is called.
	public void Dialogue()
    {
		dialogue.SendMessage("ShowText", "Maybe this star will unlock the gate...");
		AudioSource.PlayClipAtPoint(dialogueAudio, transform.position, 3.3f);
		
    }

  //Animation methods.

	public void IdleAni (){
		anim.CrossFade (IDLE);
	}

	public void RunAni (){
		anim.CrossFade (RUN);
	}

	public void AttackAni (){
		anim.CrossFade (ATTACK);
	}

	public void DamageAni (){
		
		anim.CrossFade (DAMAGE);
	}

	public void DeathAni (){
		anim.CrossFade (DEATH);
	}
}
