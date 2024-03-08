using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomMon_Ani_Test : MonoBehaviour {

	public Player player;
	public int attack = 2;
	private bool hasColliderBeenTriggered = false;
	public int health = 10;
	public float runSpeed = 2.0f;

	Animation anim;
	public const string IDLE	= "Idle";
	public const string RUN		= "Run";
	public const string ATTACK	= "Attack";
	public const string DAMAGE	= "Damage";
	public const string DEATH	= "Death";

	


	void Start () {
		anim = GetComponent<Animation>();
	}

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

	private void RunTowardsPlayer()
    {
		transform.LookAt(player.transform.position);
		transform.position = Vector3.MoveTowards(transform.position, player.transform.position, runSpeed * Time.deltaTime);
		RunAni();
    }

	public void DamageToHealth(int damage)
    {
		health -= damage;
		DamageAni();

		if (health <= 0)
        {
			DeathAni();
			Destroy(gameObject, 3f);
        }
    }

	public void Attack()
	{
		AttackAni();
	}

	public void AttackDamage()
    {
		if (hasColliderBeenTriggered)
        {
			player.TakeDamage(attack);
			
        }
    }



	private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
			hasColliderBeenTriggered = true;
			player = col.gameObject.GetComponent<Player>();
        }
    }

  

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
