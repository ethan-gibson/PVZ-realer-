using UnityEngine;
using UnityEngine.Pool;

public class Zombie : MonoBehaviour
{
	public ZombieBase zombieBase;
	private float currentHealth;
	public IObjectPool<Zombie> Pool;
	void Start()
	{
		currentHealth = zombieBase.MaxHealth;
	}
	void Update()
	{
		move();
	}
	private void OnDisable()
	{
		resetZombie();
	}
	private void move()
	{
		transform.position -= Vector3.right * zombieBase.Speed * Time.deltaTime;
	}
	public void CallTakeDamage(int damage)
	{
		TakeDamage(damage);
	}
	private void TakeDamage(int damage)
	{
		currentHealth -= damage;
		if (currentHealth <= 0)
		{
			int result = Random.Range(0, 1);
			if (result == 1)
			{
				ZombieSpawner.Instance.spawnZombie();
			}
			returnToPool();
		}
	}
	private void returnToPool()
	{
		Pool.Release(this);
	}
	private void resetZombie()
	{
		currentHealth = zombieBase.MaxHealth;

	}
}
