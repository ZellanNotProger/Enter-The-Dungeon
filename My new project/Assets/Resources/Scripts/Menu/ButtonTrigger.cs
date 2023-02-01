using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D other)
    {
            animator.SetBool("IsEntered", true);
    } 

    private void OnTriggerExit2D(Collider2D other)
    {
            animator.SetBool("IsEntered", false);
    }
}
