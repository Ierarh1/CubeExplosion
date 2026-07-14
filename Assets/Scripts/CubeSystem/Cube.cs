using System;
using UnityEngine;

[DisallowMultipleComponent]
public class Cube : MonoBehaviour
{
    public event Action<Cube> Clicked;

    public float SplitChance { get; private set; } = 1f;

    public void SetSplitChance(float chance)
    {
        SplitChance = chance;
    }

    public void Click()
    {
        Clicked?.Invoke(this);
    }
}
