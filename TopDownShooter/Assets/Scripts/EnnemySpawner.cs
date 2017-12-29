using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour, ITimeable
{
	public Timer timer;
	public BoxCollider2D[] spawnBoxes;
	public GameObject[] ennemys;
	private float nextSpawn;
    private TimeSpan time;

    public void UpdateTime(TimeSpan timePassed)
    {
        time += timePassed;
    }

    void Start()
	{
		nextSpawn = 2;
        time = TimeSpan.Zero;
        timer.Attach(this);
	}
	void Update()
	{
        if (nextSpawn <= time.TotalSeconds)
        {
            Bounds bound = spawnBoxes[UnityEngine.Random.Range(0, spawnBoxes.Length)].bounds;
            Vector3 point = new Vector3(UnityEngine.Random.Range(bound.min.x, bound.max.x), UnityEngine.Random.Range(bound.min.y, bound.max.y));
            Instantiate(ennemys[UnityEngine.Random.Range(0, ennemys.Length)], point, new Quaternion(0, 0, 0, 0));
            nextSpawn += UnityEngine.Random.Range(3.0f, 6.0f);
            Debug.Log("nex in : " + nextSpawn);
        }
	}
}