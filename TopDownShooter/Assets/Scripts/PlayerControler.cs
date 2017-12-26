using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour, Shooter {
	public Text lifeIU;
    public int lifes = 5;
    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    private float angle = 90;
    private float ptsAngle;
    private float diff;
    public Gun gun;
    private Vector3 pointToLook;
    private Camera mainCamera;
	void Start () {
		lifeIU.text = "Lifes : " + lifes.ToString();
        myRigidbody = GetComponent<Rigidbody2D>();
        mainCamera = FindObjectOfType<Camera>();
    }
    void Update()
    {

        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.forward, Vector3.zero);
        //Debug.DrawLine(Vector3.forward, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            pointToLook = cameraRay.GetPoint(rayLength);
            //Debug.DrawLine(cameraRay.origin, pointToLook, Color.red);
            //Debug.DrawLine(transform.position, pointToLook);
            ptsAngle = Mathf.Atan2(pointToLook.y - transform.position.y, pointToLook.x - transform.position.x) * (180f / Mathf.PI);
            diff = ptsAngle - angle;
            angle = ptsAngle;
            gun.transform.RotateAround(transform.position, Vector3.forward, diff);
            gun.setShooter(this);
            //Debug.Log(getPointToLook().x + "" + getPointToLook().y);
        }
        if (Input.GetButton("Fire1"))
           gun.isFiring = true;
        else
        {
            gun.isFiring = false;
        }
        
    }
    // Update is called once per frame
    void FixedUpdate () {
        myRigidbody.velocity = moveVelocity;	
	}

    public bool touched(Shooter shooter){
        if (shooter.hurt(this))
        {
            lifes--;
			lifeIU.text = "Lifes : " + lifes.ToString();
			if (lifes <= 0)
				Destroy (this.gameObject);
            return true;
        }
        return false;
    }

    public bool hurt(PlayerControler shooter)
    {
        return false;
    }

    public bool hurt(Ennemy shooter)
    {
        return true;
    }
}
