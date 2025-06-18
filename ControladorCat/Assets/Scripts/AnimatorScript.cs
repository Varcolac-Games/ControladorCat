using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    Animator m_Animator;
    Rigidbody m_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Animator.SetFloat("speed", m_Rigidbody.velocity.magnitude);
    }

    private void LateUpdate()
    {
        Vector3 velocity = m_Rigidbody.velocity;

        // Ignoramos la componente vertical (Y)
        Vector3 flatVelocity = new Vector3(velocity.x, 0, velocity.z);

        if (flatVelocity.sqrMagnitude > 0.01f)
        {
            Vector3 forward = flatVelocity.normalized;

            // Calculamos el ángulo hacia esa dirección en plano XZ
            float angle = Mathf.Atan2(forward.x, forward.z) * Mathf.Rad2Deg;

            // Rotamos solo en Y
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    }
}
