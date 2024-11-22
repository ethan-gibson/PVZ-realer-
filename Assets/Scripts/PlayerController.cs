using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float speed = 10;
	[SerializeField] private float shootDelay = 0.2f;
	[SerializeField] private GameObject playerProjectile;
	private bool canShoot = true;

	void Update()
	{
		if (Input.GetKey(KeyCode.W))
		{
			moveUp();
		}
		if (Input.GetKey(KeyCode.S))
		{
			moveDown();
		}
		if (Input.GetKeyDown(KeyCode.Space) && canShoot)
		{
			shoot();
		}
	}
	private void moveUp()
	{
		transform.position += Vector3.forward * speed * Time.deltaTime;
	}
	private void moveDown()
	{
		transform.position -= Vector3.forward * speed * Time.deltaTime;
	}
	private void shoot()
	{
		Instantiate(playerProjectile, transform);
	}
	private IEnumerator shootCooldownAsync()
	{
		canShoot = false;
		yield return new WaitForSeconds(shootDelay);
		canShoot = true;
	}
}
