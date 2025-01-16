using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISortingAlgorithm
{
    IEnumerator SortAndAnimate(List<GameObject> cubes, float animationSpeed);
}
