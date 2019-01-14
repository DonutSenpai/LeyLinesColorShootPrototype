using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
	public Color projectileColor;
	public bool addColor = true;
	bool isUsed = false;
	public GameObject instantiater;

	private void Start()
	{
		Invoke("RemoveSelfFromWorld", 10f);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (projectileColor != Color.black && isUsed == false)
		{

			Debug.Log("Collision happened");

			ColorVisualizer hitVisualizer = collision.gameObject.GetComponent<ColorVisualizer>();

			if (hitVisualizer != null && hitVisualizer.isProjectile == false)
			{

				if (addColor)
				{
					hitVisualizer.AddColor(projectileColor);
					DisableProjectile();
				}
				else
				{
					hitVisualizer.SubtractColor(projectileColor);
					DisableProjectile();
				}
			}

		}
	}

	void DisableProjectile()
	{
		GetComponent<ColorVisualizer>().SetColor(Color.black);
		isUsed = true;
	}

	void RemoveSelfFromWorld()
	{
		Destroy(gameObject);
	}

}