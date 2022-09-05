using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField] private Collider2D _jumpBox;
    [SerializeField] private LayerMask _floor;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _JumpTime;


    private Rigidbody2D _rigidbody;
    private bool _jumping;
    private float _jumpProgress;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GetOnGround())
        {
            StartJump();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopJump();
        }
    }

    private void FixedUpdate()
    {
        Move();

        if (Input.GetKey(KeyCode.Space) && _jumping)
        {
            ProcessJump();
        }
    }

    private void Move()
    {
        var horizontal = Input.GetAxis("Horizontal");

        var horizontalOffset = Time.fixedDeltaTime * horizontal * _speed;
        var VerticalOffset = _rigidbody.velocity.y;

        _rigidbody.velocity = new Vector2(horizontalOffset, VerticalOffset);
    }

    private bool GetOnGround()
    {
        var cenrter = _jumpBox.bounds.center;
        var size = _jumpBox.bounds.size;

        var ground = Physics2D.OverlapBox(cenrter, size, 90, _floor);

        return ground.bounds.center.y < cenrter.y;
    }

    private void StartJump()
    {
        _jumping = true;
    }

    private void ProcessJump()
    {
        if (_jumpProgress < _JumpTime)
        {
            var horizontalOffset = _rigidbody.velocity.x;
            var VerticalOffset = Time.fixedDeltaTime * _jumpSpeed;

            _rigidbody.velocity = new Vector2(horizontalOffset, VerticalOffset);

            _jumpProgress += Time.fixedDeltaTime;
        }

        else
        {
            StopJump();
        }
    }

    private void StopJump()
    {
        _jumping = false;
        _jumpProgress = 0;
    }
}