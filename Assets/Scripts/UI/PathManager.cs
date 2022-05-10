using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public struct Path
{
    public float pathDuration;
    public Transform[] points;
}

public class PathManager : MonoBehaviour
{
    [SerializeField] private float pathDuration;
    [SerializeField] private List<Path> pathsTransformsList;

    private List<Vector3[]> pathPointsList = new List<Vector3[]>();

    public static Func<int, Vector3[]> GetRandomPath;

    public static Func<int, float> GetPathDuration;

    public static Func<int> GetRandomPathNumber;

    private void Awake()
    {
        Initialize();
        GetRandomPath = ReturnRandomPath;
        GetPathDuration = ReturnPathDuration;
        GetRandomPathNumber = RetunRandomNumber;
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

    private int RetunRandomNumber()
    {
        return Random.Range(0, pathPointsList.Count);
    }

    private Vector3[] ReturnRandomPath(int i)
    {
        return pathPointsList[i];
    }


    private float ReturnPathDuration(int i)
    {
        return pathsTransformsList[i].pathDuration;
    }

}
