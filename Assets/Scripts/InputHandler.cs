using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private string _horizontalAxis = "Horizontal";
    private string _verticalAxis = "Vertical";
    private string _mouseXAxis = "Mouse X";
    private string _mouseYAxis = "Mouse Y";

    public Vector2 MoveInput { get; private set; }
    public Vector2 LookInput { get; private set; }

    private void Update()
    {
        MoveInput = new Vector2(Input.GetAxis(_horizontalAxis), Input.GetAxis(_verticalAxis));
        LookInput = new Vector2(Input.GetAxis(_mouseXAxis), Input.GetAxis(_mouseYAxis));
    }
}
