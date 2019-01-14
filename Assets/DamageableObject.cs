using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableObject : MonoBehaviour {

	float health = 100f;

	private void Start()
	{
		TakeDamage(25f);
	}

	public void TakeDamage(float damage)
	{
		health -= damage;
		Debug.LogFormat("{0}", health);
		if (health <= 0f)
		{
			Object.Destroy(this.gameObject);
		}
	}

	
	
	
}
