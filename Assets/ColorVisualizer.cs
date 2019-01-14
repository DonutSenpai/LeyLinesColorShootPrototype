using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class handles setting the colors on meshes, and color schemes
public class ColorVisualizer : MonoBehaviour
{
	public bool isProjectile = false;
	ProjectileScript projectileScript;
	Material material;

    //Schemes for colors and shapes
	[SerializeField]
	MeshColorCombination[] colorCombinationArray;

    //If the mesh is a certain color, set it to be the corresponding mesh
	[System.Serializable]
	public class MeshColorCombination
	{
		public Mesh mesh;
		public Color color;
	}

	private void Awake()
	{
		material = GetComponent<MeshRenderer>().material;
		SetColor(Color.black);
	}

    //Since colors are just structs of floats, it's easy to add the numbers to get new colors
	public void AddColor(Color colorToAdd)
	{
		Color currentColor = material.color;
		Color newColor = currentColor + colorToAdd;

		SetColor(newColor);
	}

	public void SubtractColor(Color colorToSubtract)
	{
		Color currentColor = material.color;
		Color newColor = currentColor - colorToSubtract;

		SetColor(newColor);
	}

	public void SetColor(Color color)
	{
		color.r = Mathf.Clamp(color.r, 0f, 1f);
		color.g = Mathf.Clamp(color.g, 0f, 1f);
		color.b = Mathf.Clamp(color.b, 0f, 1f);

		material.color = color;

        //Checks if every value of color is the same as one of the colors in the color combination scheme,
        //if so, change mesh to be the corresponding shape.
		foreach (MeshColorCombination combination in colorCombinationArray)
		{
			if (Mathf.Abs(color.r - combination.color.r) < 0.01f &&
				Mathf.Abs(color.g - combination.color.g) < 0.01f &&
				Mathf.Abs(color.b - combination.color.b) < 0.01f)
			{
				GetComponent<MeshFilter>().mesh = combination.mesh;
			}
		}

	}

}
