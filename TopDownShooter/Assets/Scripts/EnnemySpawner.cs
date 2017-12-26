using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour
{
	public Timer timer;
	public BoxCollider2D[] spawnBoxes;
	public GameObject[] ennemys;
	private float nextSpawn;
	void Start()
	{
		nextSpawn = 2;
	}
	void Update()
	{
		if (nextSpawn <= timer.getTime().TotalSeconds) {
			Bounds bound = spawnBoxes [Random.Range(0,spawnBoxes.Length)].bounds;
			Vector3 point = new Vector3 (Random.Range(bound.min.x, bound.max.x), Random.Range(bound.min.y,bound.max.y));
			Instantiate (ennemys [Random.Range (0, ennemys.Length)], point, new Quaternion(0,0,0,0) );
			nextSpawn += Random.Range (3.0f, 6.0f);
			Debug.Log ("nex in : " + nextSpawn);

		}
	}
}

