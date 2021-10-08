

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHP : MonoBehaviour {

	[SerializeField] private float health = 100;

	public float currentHealth
	{
		get{ return health; }
	}

	public void Adjust(float value)
	{
		health += value;

		if(health <= 0)
		{
			Destroy(gameObject);
		}
	}
}
