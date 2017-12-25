using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControler : MonoBehaviour {
    private Shooter shooter;
    public float speed = 5;
    private Vector3 target;
    public bool outOfScreen = false;
    void Start () {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * speed/2, transform.localScale.z);
    }

    void FixedUpdate()
    {
        if (target != new Vector3(0, 0, 0))
        {
            transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
        }
    }
    public void setTarget(Vector3 target)
    {
        this.target = target;
    }
    public void setShooter(Shooter shooter)
    {
        this.shooter = shooter;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Shooter victim = other.GetComponent<Shooter>();
        if (victim.touched(shooter))
            Destroy(this);
        
    }
    
}
