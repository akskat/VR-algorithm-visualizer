using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSort : MonoBehaviour, ISortingAlgorithm
{
    public IEnumerator SortAndAnimate(List<GameObject> cubes, float animationSpeed)
    {
        yield return QuickSortHelper(cubes, 0, cubes.Count - 1, animationSpeed);
    }

    private IEnumerator QuickSortHelper(List<GameObject> cubes, int low, int high, float animationSpeed)
    {
        if (low < high)
        {
            int pi = Partition(cubes, low, high);

            yield return QuickSortHelper(cubes, low, pi - 1, animationSpeed);
            yield return QuickSortHelper(cubes, pi + 1, high, animationSpeed);
        }
    }

    private int Partition(List<GameObject> cubes, int low, int high)
    {
        float pivot = cubes[high].transform.localScale.y;
        int i = (low - 1);

        for (int j = low; j < high; j++)
        {
            if (cubes[j].transform.localScale.y < pivot)
            {
                i++;
                Swap(cubes, i, j);
            }
        }
        Swap(cubes, i + 1, high);
        return i + 1;
    }

    private void Swap(List<GameObject> cubes, int indexA, int indexB)
    {
        GameObject temp = cubes[indexA];
        cubes[indexA] = cubes[indexB];
        cubes[indexB] = temp;
    }
}
