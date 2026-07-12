using System;
using UnityEngine;

[DisallowMultipleComponent]
public class Cube : MonoBehaviour
{
    public static event Action<Cube> Clicked;

    public float SplitChance { get; set; } = 1f;

    public void Click()
    {
        Clicked?.Invoke(this);
    }
}
