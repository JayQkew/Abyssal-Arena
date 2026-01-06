using Slime;
using UnityEngine;

public class IrisMove : MonoBehaviour
{
    private Vector2 _parent;

    [HideInInspector] public InputHandler inputHandler;

    private void Start()
    {
        _parent = transform.parent.localPosition;
        inputHandler = transform.parent.parent.GetComponent<InputHandler>();
    }

    private void Update()
    {
        EyeFollow(inputHandler.moveInput);
    }

    private void EyeFollow(Vector3 pos)
    {
        Vector2 direction = new Vector2((pos.x - _parent.x) / 2, (pos.y - _parent.y) / 2); //15 -0.443f/15
        transform.localPosition = direction;
    }
}