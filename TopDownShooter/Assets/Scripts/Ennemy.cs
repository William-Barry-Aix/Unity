using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour, Shooter
{
    private float angle = 90;
    private float ptsAngle;
    private float diff;
    public Gun gun;
    private Vector3 pointToLook;
    private GameObject Cible;
    public int lifes = 5;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		if (Cible = GameObject.FindGameObjectWithTag ("Player")) {
			pointToLook = Cible.transform.position;
			ptsAngle = Mathf.Atan2 (pointToLook.y - transform.position.y, pointToLook.x - transform.position.x) * (180f / Mathf.PI);
			diff = ptsAngle - angle;
			angle = ptsAngle;
			gun.transform.RotateAround (transform.position, Vector3.forward, diff);
			gun.setTarget (this.pointToLook);
			gun.setShooter (this);
			gun.isFiring = true;
		} else
			gun.isFiring = false;
    }
    public bool touched(Shooter shooter)
    {
        if (shooter.hurt(this))
        {
            lifes--;
			if (lifes <= 0)
				Destroy(this.gameObject);
            return true;
        }
        return false;
    }

    public bool hurt(PlayerControler shooter)
    {
        return true;
    }

    public bool hurt(Ennemy shooter)
    {
        return false;
    }


}