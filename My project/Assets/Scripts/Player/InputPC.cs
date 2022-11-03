using UnityEngine;


public class InputPC : MonoBehaviour
{
    [SerializeField] private PersonMovement _personMovement;

    private readonly string _horizontal = "Horizontal";

    private void Start()
    {
        _personMovement = GetComponent<PersonMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _personMovement.StartJump();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _personMovement.StopJump();
        }
    }

    private void FixedUpdate()
    {
        var horizontal = Input.GetAxis(_horizontal);

        _personMovement.Move(horizontal);

        if (Input.GetKey(KeyCode.Space))
        {
            _personMovement.ProcessJump();
        }
    }
}