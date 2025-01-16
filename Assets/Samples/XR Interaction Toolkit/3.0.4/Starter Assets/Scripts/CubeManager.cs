using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public GameObject cubePrefab; // Prefab for kubene
    public int numberOfCubes = 20; // Antall kuber som skal genereres
    private List<GameObject> cubes = new List<GameObject>(); // Liste over kubene
    private Transform currentTableSurface; // Gjeldende bordoverflate

    /// <summary>
    /// Setter bordoverflaten som skal brukes
    /// </summary>
    /// <param name="tableSurface">Transformen til bordoverflaten</param>
    public void SetTableSurface(Transform tableSurface)
    {
        if (tableSurface == null)
        {
            Debug.LogError("SetTableSurface: Bordoverflaten er null eller ugyldig!");
            return;
        }

        currentTableSurface = tableSurface;
        Debug.Log($"SetTableSurface: Bordoverflate satt til {tableSurface.name}");
    }

    /// <summary>
    /// Genererer kuber på den aktuelle bordoverflaten
    /// </summary>
    public void GenerateCubes()
    {
        if (currentTableSurface == null)
        {
            Debug.LogError("GenerateCubes: Ingen bordoverflate er satt!");
            return;
        }

        ClearCubes();

        Vector3 tableCenter = currentTableSurface.position;
        float xStart = tableCenter.x - (numberOfCubes * 0.15f) / 2;
        float yPosition = tableCenter.y + currentTableSurface.localScale.y / 2 + 0.05f; // Litt over bordet
        float zPosition = tableCenter.z;

        for (int i = 0; i < numberOfCubes; i++)
        {
            float height = Random.Range(0.2f, 1f); // Tilfeldig høyde
            float xPosition = xStart + i * 0.15f;
            Vector3 spawnPosition = new Vector3(xPosition, yPosition, zPosition);

            // Opprett kuben
            GameObject cube = Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
            cube.transform.localScale = new Vector3(0.1f, height, 0.1f); // Sett størrelse
            cubes.Add(cube);

            // Sett farge basert på høyde
            Color heightColor = Color.Lerp(Color.red, Color.green, height / 1f);
            cube.GetComponent<Renderer>().material.color = heightColor;
        }

        Debug.Log($"GenerateCubes: {numberOfCubes} kuber generert på {currentTableSurface.name}");
    }

    /// <summary>
    /// Fjerner alle kuber
    /// </summary>
    private void ClearCubes()
    {
        foreach (var cube in cubes)
        {
            if (cube != null)
                Destroy(cube);
        }
        cubes.Clear();
        Debug.Log("ClearCubes: Alle kuber fjernet.");
    }

    /// <summary>
    /// Henter listen med kuber
    /// </summary>
    /// <returns>Listen over kuber</returns>
    public List<GameObject> GetCubes()
    {
        return cubes;
    }
}
