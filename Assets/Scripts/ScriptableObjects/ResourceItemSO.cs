using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(order = 0, fileName = "ResourceItemSO", menuName = "Data/Items/ResourceItem")]
    public class ResourceItemSO : ScriptableObject
    {
        /*        private static float _currentAmount;

                public static float CurrentAmount
                {
                    get => _currentAmount;
                    set
                    {
                        _currentAmount = value;
                        OnAmountChanged?.Invoke(_currentAmount);
                    }
                }

                public static event Action<float> OnAmountChanged;
            }*/
    }
}
