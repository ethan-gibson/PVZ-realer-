using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ZombieBase", menuName = "ScriptableObjects/Zombies", order = 1)]
public class ZombieBase : ScriptableObject
{
	[field:SerializeField] public float Speed = 4;
	[field:SerializeField] public int MaxHealth = 15;
}
