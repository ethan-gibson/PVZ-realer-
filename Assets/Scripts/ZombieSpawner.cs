using System.Collections;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
	[SerializeField] private float spawnCooldown = 5;
	public static ZombieSpawner Instance;
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
		StartCoroutine(spawning());
	}
	public void spawnZombie()
	{
		if (ZombiePool.Instance == null) { return; }
		ZombiePool.Instance.Spawn();
	}
	private IEnumerator spawning()
	{
		spawnZombie();
		yield return new WaitForSeconds(spawnCooldown);
		if (spawnCooldown >= 0.5f)
		{
			spawnCooldown -= 0.1f;
		}
		StartCoroutine(spawning());
	}
}
