using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public struct Path
{
    public Transform[] points;
}

public class PathManager : MonoBehaviour
{
    [SerializeField] private List<Path> pathsTransformsList;

    private List<Vector3[]> pathPointsList = new List<Vector3[]>();

    public static Func<Vector3[]> GetRandomPath;

    private void Awake()
    {
        Initialize();
        GetRandomPath = ReturnRandomPath;
    }

    private void Initialize()
    {
        foreach (var transformArray in pathsTransformsList)
        {
            pathPointsList.Add(new Vector3[transformArray.points.Length]);
        }

        for (int x = 0; x < pathsTransformsList.Count; x++)
        {
            var pointTransformArray = pathsTransformsList[x];

            for (int i = 0; i < pointTransformArray.points.Length; i++)
            {
                pathPointsList[x][i] = pointTransformArray.points[i].position;
            }
        }
    }

    private Vector3[] ReturnRandomPath()
    {
        return pathPointsList[Random.Range(0, pathPointsList.Count)];
    }
}
