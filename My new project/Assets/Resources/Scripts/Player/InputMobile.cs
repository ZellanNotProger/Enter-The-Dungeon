using UnityEngine;

public class InputMobile : MonoBehaviour
{
    [SerializeField] private PersonMovement _personMovement;
    [SerializeField] private float _normalSpeed;
    [SerializeField] private float _speed;

    private bool _isJump;

    private void Start()
    {
        _personMovement = GetComponent<PersonMovement>();
        _speed = 0f;
    }

    private void FixedUpdate()
    {
        _personMovement.Move(_speed);

        if (_isJump)
        {
            _personMovement.ProcessJump();
        }
    }

    public void OnLeftButtonDown()
    {
        if (_speed >= 0f)
        {
            _speed = -_normalSpeed;
        }
    }

    public void OnRightButtonDown()
    {
        if (_speed <= 0f)
        {
            _speed = _normalSpeed;
        }
    }

    public void OnJumpButtonDown()
    {
        if (_personMovement.CheckOnGround())
        {
            _isJump = true;
            _personMovement.StartJump();
        }
    }
    public void OnJumpButtonUp()
    {
        _personMovement.StopJump();
    }

    public void OnButtonUp()
    {
        _speed = 0f;
    }
}