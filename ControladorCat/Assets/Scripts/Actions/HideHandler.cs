using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class HideHandler : MonoBehaviour
{
    [Header("Opcional")]
    public UnityEvent OnHideStart;
    public UnityEvent OnHideEnd;

    private bool isHidden = false;
    private Coroutine hideCoroutine;
    private Renderer[] renderers;
    private Collider[] colliders;

    private void Awake()
    {
        renderers = GetComponentsInChildren<Renderer>();
        colliders = GetComponentsInChildren<Collider>();
    }

    public void StartHiding(float duration)
    {
        Debug.Log("StartHiding");
        if (hideCoroutine != null)
            StopCoroutine(hideCoroutine);

        hideCoroutine = StartCoroutine(HideRoutine(duration));
    }

    private IEnumerator HideRoutine(float duration)
    {
        SetHiddenState(true);
        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;

        yield return new WaitForSeconds(duration);

        SetHiddenState(false);
        gameObject.GetComponent<SkinnedMeshRenderer>().enabled = true;
    }

    private void SetHiddenState(bool hide)
    {
        isHidden = hide;

        foreach (var r in renderers)
            r.enabled = !hide;

        foreach (var c in colliders)
            c.enabled = !hide;
    }

    public bool IsHidden() => isHidden;


}
