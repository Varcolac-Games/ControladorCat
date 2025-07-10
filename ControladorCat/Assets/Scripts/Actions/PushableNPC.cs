using UnityEngine;

public class PushableNPC : MonoBehaviour, IReactToPush
{
    public Animator animator;
    public float trust = 50f;

    public void OnPushed(PushActionData data)
    {
        Debug.Log($"{gameObject.name} fue empujado con estilo {data.style}");

        switch (data.style)
        {
            case "Zarpazo":
                trust -= 5f;
                animator?.SetTrigger("Surprised");
                break;

            case "Embestida torpe":
                trust -= 2f;
                animator?.SetTrigger("Stumble");
                break;

            case "Golpe serio":
                trust -= 15f;
                animator?.SetTrigger("Angry");
                break;
        }

        if (trust <= 0)
        {
            // reacciona hostilmente
            animator?.SetTrigger("Attack");
        }
    }
}
