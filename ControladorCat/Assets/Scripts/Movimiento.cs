using UnityEngine

public class Controller : Monobeahivor
{
	public float speed = 3;
	RigiBbody rb;
	
	void Start()
	{
		rb = GetComponent<RigiBbody>();
	}
	
	void Update()
	{
		Vector3 input = New Vector3(InputManager.Instance.Move.x, 0f , InputManager.Instance.Move.y)
		input.Normalized();
		input *= speed * Time.Deltatime();
		rb.velocity(input.x, rb.velocity.y,input.z)
		
	}
}