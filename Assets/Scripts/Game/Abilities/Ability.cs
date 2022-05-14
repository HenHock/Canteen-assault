using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public int cooldown;
    public Sprite artWork;
    public abstract void Use();
    public abstract Ability Get(Abilities ability);
}
