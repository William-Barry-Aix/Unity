using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour {
    private Camera mainCamera;
    private Vector3 pointToLook;
    private float angle = 180;
    private float ptsAngle;
    public Wall wall;


    // Use this for initialization
    void Start () {
        mainCamera = FindObjectOfType<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.forward, Vector3.zero);
        //Debug.DrawLine(Vector3.forward, Vector3.zero);
        float rayLength;
        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            float diff;
            pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.red);
            //Debug.DrawLine(transform.position, pointToLook);
            ptsAngle = Mathf.Atan2(pointToLook.y - transform.position.y,
                                   pointToLook.x - transform.position.x) * (180f / Mathf.PI);
            diff = ptsAngle - angle;
            angle = ptsAngle;
            transform.RotateAround(transform.position, Vector3.forward, diff);
            //Debug.Log(getPointToLook().x + "" + getPointToLook().y);
        }
        if (Input.GetButton("Jump"))
        {
            Instantiate(wall, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
