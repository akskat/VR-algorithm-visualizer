using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSort : MonoBehaviour, ISortingAlgorithm
{
    public IEnumerator SortAndAnimate(List<GameObject> cubes, float animationSpeed)
    {
        int n = cubes.Count;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (cubes[j].transform.localScale.y > cubes[j + 1].transform.localScale.y)
                {
                    yield return SwapCubes(cubes, j, j + 1, animationSpeed);
                }
            }
        }
    }

    private IEnumerator SwapCubes(List<GameObject> cubes, int indexA, int indexB, float animationSpeed)
    {
        GameObject cubeA = cubes[indexA];
        GameObject cubeB = cubes[indexB];
        Vector3 posA = cubeA.transform.position;
        Vector3 posB = cubeB.transform.position;

        float elapsedTime = 0f;
        while (elapsedTime < animationSpeed)
        {
            cubeA.transform.position = Vector3.Lerp(posA, posB, elapsedTime / animationSpeed);
            cubeB.transform.position = Vector3.Lerp(posB, posA, elapsedTime / animationSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cubeA.transform.position = posB;
        cubeB.transform.position = posA;

        cubes[indexA] = cubeB;
        cubes[indexB] = cubeA;
    }
}
