﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    private Shooter shooter;
    public bool isFiring;
    public BulletControler bullet;

    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;
	// Use this for initialization
	void Start () {
		
	}
	void Update () {
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                BulletControler newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletControler;
                newBullet.setShooter(shooter);
                newBullet.transform.rotation = transform.rotation;
            }
        }
        else
        {
            shotCounter = 0;
        }
	}
    public void setShooter(Shooter shooter)
    {
        this.shooter = shooter;
    }
}
