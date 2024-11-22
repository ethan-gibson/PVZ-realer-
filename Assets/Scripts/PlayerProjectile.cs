using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
	[SerializeField] private float speed = 5;

	// Update is called once per frame
	void Update()
	{
		transform.position -= Vector3.right * speed * Time.deltaTime;
	}
	private void OnTriggerEnter(Collider other)
	{
		other.GetComponent<Zombie>()?.CallTakeDamage(5);
	}
}
