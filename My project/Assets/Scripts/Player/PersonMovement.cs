using UnityEngine;

public class PersonMovement : MonoBehaviour
{
    public float _speed;

    [SerializeField] private Collider2D _jumpBox;
    [SerializeField] private LayerMask _floor;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _JumpTime;

    private SpriteRenderer _renderer;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private readonly string _runningBool = "IsRunning";
    private readonly string _jumpingBool = "IsJumping";
    private bool _jumping;
    private float _jumpProgress;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    public void Move(float horizontal)
    {
        SetSpeed(horizontal);

        SetAnimation(horizontal);
    }

    private void SetSpeed(float horizontal)
    {
        var horizontalOffset = Time.fixedDeltaTime * horizontal * _speed;
        var VerticalOffset = _rigidbody.velocity.y;

        _rigidbody.velocity = new Vector2(horizontalOffset, VerticalOffset);
    }

    private void SetAnimation(float horizontal)
    {
            _renderer = GetComponent<SpriteRenderer>();

            _renderer.flipX = horizontal < 0;

            var isRunning = horizontal != 0;

            _animator.SetBool(_runningBool, isRunning);
        
    }

    public bool CheckOnGround()
    {
        var cenrter = _jumpBox.bounds.center;
        var size = _jumpBox.bounds.size;

        var ground = Physics2D.OverlapBox(cenrter, size, 90, _floor);

        return ground.bounds.center.y < cenrter.y;
    }

    public void StartJump()
    {
        if (CheckOnGround())
        {
            _jumping = true;
        }
    }

    public void ProcessJump()
    {
        if (_jumping)
        {
            _animator.SetBool(_runningBool, false);

            if (_jumpProgress < _JumpTime)
            {
                var horizontalOffset = _rigidbody.velocity.x;
                var verticalOffset = Time.fixedDeltaTime * _jumpSpeed;

                _rigidbody.velocity = new Vector2(horizontalOffset, verticalOffset);

                _jumpProgress += Time.fixedDeltaTime;

                _animator.SetBool(_jumpingBool, true);
            }

            else
            { 
                StopJump();
            }
        }
    }

    public void StopJump()
    {
        _animator.SetBool(_jumpingBool, false);
       
         _jumping = false;
        _jumpProgress = 0;
    }
}