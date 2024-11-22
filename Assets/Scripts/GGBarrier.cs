using UnityEngine;

public class GGBarrier : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		//game over
		other.GetComponent<Zombie>()?.CallTakeDamage(100);
	}
}
