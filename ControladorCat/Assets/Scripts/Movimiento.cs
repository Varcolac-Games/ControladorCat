using UnityEngine;

namespace Iso
{
	public class Controller : MonoBehaviour
	{
		public float speed = 3;
		Rigidbody rb;

		void Start()
		{
            rb = GetComponent<Rigidbody>();
		}

		void Update()
		{
			Vector3 input = (Vector3.right * InputManager.Instance.MoveInput.x + Vector3.forward * InputManager.Instance.MoveInput.y).normalized * speed * Time.deltaTime;
			
			//input.Normalize();
			//input *= speed * Time.deltaTime;
			rb.velocity = new Vector3(input.x, rb.velocity.y, input.z);

		}
	}
}