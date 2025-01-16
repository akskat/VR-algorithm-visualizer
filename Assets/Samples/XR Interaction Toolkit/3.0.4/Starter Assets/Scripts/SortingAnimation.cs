using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingAnimation : MonoBehaviour
{
    public CubeManager cubeManager; // Referanse til CubeManager
    public MonoBehaviour sortingAlgorithm; // For å dra inn algoritmen i Unity
    private ISortingAlgorithm _sortingAlgorithm; // Intern grensesnitt-referanse
    public float animationSpeed = 1.0f;

    private void Start()
    {
        // Cast sortingAlgorithm til ISortingAlgorithm
        _sortingAlgorithm = sortingAlgorithm as ISortingAlgorithm;
        if (_sortingAlgorithm == null)
        {
            Debug.LogError("Sorting Algorithm is not a valid ISortingAlgorithm!");
        }
    }

    public void StartSorting()
    {
        if (_sortingAlgorithm == null)
        {
            Debug.LogError("Sorting Algorithm is not set!");
            return;
        }

        List<GameObject> cubes = cubeManager.GetCubes();
        if (cubes.Count > 0)
        {
            StartCoroutine(_sortingAlgorithm.SortAndAnimate(cubes, animationSpeed));
        }
    }
}
