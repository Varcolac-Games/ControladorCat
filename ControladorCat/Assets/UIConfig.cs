
using UnityEngine;

public class UIConfig : MonoBehaviour
{
    private void Awake()
    {

#if UNITY_STANDALONE_WIN
        Destroy(gameObject);
#endif
    }
}
