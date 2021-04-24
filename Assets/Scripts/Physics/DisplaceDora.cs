using UnityEngine;

public class DisplaceDora : MonoBehaviour
{
    public Joystick joystick = null;
    public float reachTime = 1;
    public float displacement = 0.5f;

    private Vector3 _currrentDirection = new Vector3();
    private Vector3 _wantedDirection = new Vector3();
    private Timer timer = new Timer();
    private bool _isUsingTouch = false;
    private PlayerInput _input = null;

    private void Start()
    {
        _input = GetComponentInParent<PlayerInput>();
        _currrentDirection = transform.localPosition;
    }

    private void Update()
    {
        Vector3 newDirection = transform.localPosition;
        newDirection[0] = _input.horizontal;
        newDirection[1] = _input.vertical;
        newDirection.Normalize();
        newDirection *= displacement;

        SetWantedDestination(newDirection);

        _currrentDirection = Vector3.Lerp(_currrentDirection, _wantedDirection, timer.GetProgressRatio());
        transform.localPosition = _currrentDirection;
    }

    private void SetWantedDestination(Vector3 newDireciton)
    {
        if (newDireciton != _wantedDirection)
        {
            timer.Start(reachTime);
            _wantedDirection = newDireciton;
        }
    }
}
