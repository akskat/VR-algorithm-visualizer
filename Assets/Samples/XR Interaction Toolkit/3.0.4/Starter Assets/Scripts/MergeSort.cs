using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeSort : MonoBehaviour, ISortingAlgorithm
{
    public IEnumerator SortAndAnimate(List<GameObject> cubes, float animationSpeed)
    {
        yield return MergeSortHelper(cubes, 0, cubes.Count - 1, animationSpeed);
    }

    private IEnumerator MergeSortHelper(List<GameObject> cubes, int left, int right, float animationSpeed)
    {
        if (left < right)
        {
            int middle = left + (right - left) / 2;

            yield return MergeSortHelper(cubes, left, middle, animationSpeed);
            yield return MergeSortHelper(cubes, middle + 1, right, animationSpeed);
            yield return Merge(cubes, left, middle, right, animationSpeed);
        }
    }

    private IEnumerator Merge(List<GameObject> cubes, int left, int middle, int right, float animationSpeed)
    {
        int n1 = middle - left + 1;
        int n2 = right - middle;

        GameObject[] leftArray = new GameObject[n1];
        GameObject[] rightArray = new GameObject[n2];

        for (int i = 0; i < n1; i++)
            leftArray[i] = cubes[left + i];
        for (int j = 0; j < n2; j++)
            rightArray[j] = cubes[middle + 1 + j];

        int iIndex = 0, jIndex = 0, kIndex = left;

        while (iIndex < n1 && jIndex < n2)
        {
            if (leftArray[iIndex].transform.localScale.y <= rightArray[jIndex].transform.localScale.y)
            {
                yield return AnimateSwap(cubes, kIndex, leftArray[iIndex], animationSpeed);
                iIndex++;
            }
            else
            {
                yield return AnimateSwap(cubes, kIndex, rightArray[jIndex], animationSpeed);
                jIndex++;
            }
            kIndex++;
        }

        while (iIndex < n1)
        {
            yield return AnimateSwap(cubes, kIndex, leftArray[iIndex], animationSpeed);
            iIndex++;
            kIndex++;
        }

        while (jIndex < n2)
        {
            yield return AnimateSwap(cubes, kIndex, rightArray[jIndex], animationSpeed);
            jIndex++;
            kIndex++;
        }
    }

    private IEnumerator AnimateSwap(List<GameObject> cubes, int index, GameObject cube, float animationSpeed)
    {
        Vector3 startPosition = cube.transform.position;
        Vector3 targetPosition = cubes[index].transform.position;

        float elapsedTime = 0f;
        while (elapsedTime < animationSpeed)
        {
            cube.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / animationSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        cube.transform.position = targetPosition;
        cubes[index] = cube;
    }
}
