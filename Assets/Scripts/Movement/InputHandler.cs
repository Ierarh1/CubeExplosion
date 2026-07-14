using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private string _horizontalAxis = "Horizontal";
    private string _verticalAxis = "Vertical";
    private string _mouseXAxis = "Mouse X";
    private string _mouseYAxis = "Mouse Y";

    public Vector2 MoveInput()
    { 
        return new Vector2(Input.GetAxis(_horizontalAxis), Input.GetAxis(_verticalAxis));
    }

    public Vector2 LookInput()
    {
        return new Vector2(Input.GetAxis(_mouseXAxis), Input.GetAxis(_mouseYAxis));
    }
}
