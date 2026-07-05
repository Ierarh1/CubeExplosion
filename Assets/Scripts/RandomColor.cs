using UnityEngine;

public class RandomColor : MonoBehaviour
{
    private bool _randomizeOnStart = true;
    private bool _allowMultipleChanges = true;

    private bool _hasBeenColored = false;

    private void Start()
    {
        if (_randomizeOnStart)
        {
            ApplyRandomColor();
        }
    }

    public void ApplyRandomColor()
    {
        if (!_allowMultipleChanges && _hasBeenColored)
            return;

        MeshRenderer renderer = GetComponent<MeshRenderer>();
        if (renderer == null) return;

        renderer.material.color = Random.ColorHSV(0f, 1f, 0.55f, 1f, 0.65f, 1f);
        
        _hasBeenColored = true;
    }
}