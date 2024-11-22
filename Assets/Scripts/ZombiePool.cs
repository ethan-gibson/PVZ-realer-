using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ZombiePool : MonoBehaviour
{
	[SerializeField] GameObject zombieObject;
	[SerializeField] private ZombieBase SunflowerZombiePrefab;
	[SerializeField] private ZombieBase PeashooterZombiePrefab;
	[SerializeField] private ZombieBase WalnutZombiePrefab;
	[SerializeField] private Material SunflowerZombieMat;
	[SerializeField] private Material PeashooterZombieMat;
	[SerializeField] private Material WalnutZOmbieMat;
	[SerializeField] private List<Transform> spawnPoints = new();
	public static ZombiePool Instance;
	private void Start()
	{
		if (Instance != this && Instance != null)
		{
			Destroy(this);
		}
		else
		{
			Instance = this;
		}
	}
	private static int maxZombies = 80;
	private static int maxZombiesStack = 80;
	public IObjectPool<Zombie> Pool
	{
		get
		{
			if (_pool == null)
			{
				_pool = new ObjectPool<Zombie>(
					createdPooledItem, onTakeFromPool, onReturnedToPool, onDestroyPoolObject, true, maxZombiesStack, maxZombies
				);
			}
			return _pool;
		}
	}
	private IObjectPool<Zombie> _pool;
	private Zombie createdPooledItem()
	{
		var temp = Instantiate(zombieObject, GetSpawnLocation());
		var tempCode = temp.GetComponent<Zombie>();
		temp.GetComponent<Zombie>().Pool = Pool;
		return tempCode;
	}
	private void onReturnedToPool(Zombie zombie)
	{
		zombie.gameObject.SetActive(false);
	}
	private void onTakeFromPool(Zombie zombie)
	{
		zombie.gameObject.SetActive(true);
	}
	private void onDestroyPoolObject(Zombie zombie)
	{
		Destroy(zombie.gameObject);
	}
	public void Spawn()
	{
		var temp = Pool.Get();
		var chosen = Random.Range(0, 100);
		if (chosen > 95)
		{
			temp.GetComponent<Zombie>().zombieBase = WalnutZombiePrefab;
			temp.GetComponent<Renderer>().material = WalnutZOmbieMat;

		}
		if (chosen > 70)
		{
			temp.GetComponent<Zombie>().zombieBase = PeashooterZombiePrefab;
			temp.GetComponent<Renderer>().material = PeashooterZombieMat;

		}
		else
		{
			temp.GetComponent<Zombie>().zombieBase = SunflowerZombiePrefab;
			temp.GetComponent<Renderer>().material = PeashooterZombieMat;

		}

		temp.transform.position = GetSpawnLocation().position;
	}
	public Transform GetSpawnLocation()
	{
		Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
		return spawnPoint;
	}
}
