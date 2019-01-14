using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorShootController : MonoBehaviour
{
	Camera myCamera;

	ProjectileScript projectileScriptComp;
	bool rightClick, leftClick;

	//reference to the little ball that shoots other balls(for UI purposes it represents the color you will shoot)
	ColorVisualizer currentColorVisualizer;

	//B(black) & RGB colors
	List<Color> colors = new List<Color>();
	Color currentColor = new Color();
	int currentColorIndex = 0;

	//Projectile prefab and spawnpoint
	public GameObject projectilePrefab;
	public Transform spawnPoint;

	private void Start()
	{
		Debug.LogFormat("{0}, {1}, {2}", currentColor.r, currentColor.g, currentColor.b);

		//Adds all the colors to the colorsList
		colors.Add(Color.black);
		colors.Add(Color.red);
		colors.Add(Color.green);
		colors.Add(Color.blue);

		currentColorVisualizer = GetComponentInChildren<ColorVisualizer>();
		currentColorVisualizer.AddColor(colors[currentColorIndex]);
	}

	void Update()
	{
		UpdateSelectedColor();

		//Handles input for the shooting (negative or positive(i.e add or subtract c))
		rightClick = Input.GetMouseButtonDown(1);
		leftClick = Input.GetMouseButtonDown(0);

		if (leftClick || rightClick)
		{
            LobShot();
		}
	}

	void UpdateSelectedColor()
	{
		int oldIndex = currentColorIndex;

		if (Input.GetKeyDown(KeyCode.Q))
		{
			currentColorIndex--;
		}

		if (Input.GetKeyDown(KeyCode.E))
		{
			currentColorIndex++;
		}

		currentColorIndex = Mathf.Clamp(currentColorIndex, 0, colors.Count);

		if (oldIndex != currentColorIndex)
		{
			currentColorVisualizer.SetColor(colors[currentColorIndex]);
		}
	}

	void LobShot()
	{
		Debug.Log("LobShot");
		//Set up references and instantiate
		GameObject spawnedProjectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
		Rigidbody spawnedProjectileRB = spawnedProjectile.GetComponent<Rigidbody>();
		projectileScriptComp = spawnedProjectile.GetComponent<ProjectileScript>();
		ColorVisualizer projectileColorVisualizer = spawnedProjectile.GetComponent<ColorVisualizer>();

		//Change variables and adding force
		spawnedProjectileRB.AddForce(spawnedProjectile.transform.forward * Time.deltaTime * 50000f);
		projectileColorVisualizer.AddColor(colors[currentColorIndex]);
		projectileColorVisualizer.isProjectile = true;
		projectileScriptComp.projectileColor = colors[currentColorIndex];
		projectileScriptComp.instantiater = this.gameObject;

		if (rightClick)
		{
			projectileScriptComp.addColor = false;
		}
	}	
}