using UnityEngine;

public class DialogueAnimator : MonoBehaviour
{
    [SerializeField] private Animator startButtonAnim;
    [SerializeField] private DialogueManager dialogueManager;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        startButtonAnim.SetBool("IsOpen", true);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        startButtonAnim.SetBool("IsOpen", false);
        dialogueManager.EndDialogue();
    }
}
