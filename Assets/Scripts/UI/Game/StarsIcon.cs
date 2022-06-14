using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsIcon : MonoBehaviour
{
    [SerializeField] private Sprite stars_0;
    [SerializeField] private Sprite stars_1;
    [SerializeField] private Sprite stars_2;
    [SerializeField] private Sprite stars_3;

    private static IDictionary<int, Sprite> starsIcon;

    private void Awake()
    {
        starsIcon = new Dictionary<int, Sprite>()
        {
            {0, stars_0 },
            {1, stars_1},
            {2, stars_2},
            {3, stars_3},
        };
    }

    public static Sprite GetIcon(int val)
    {
        return starsIcon[val];
    }
}
