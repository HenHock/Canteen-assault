using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability: MonoBehaviour
{
    public int cooldown;
    public Sprite UIImage;
    public abstract void Use();
}
