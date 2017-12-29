using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, ITimeable {
    private TimeSpan timeLeft;
    private Timer timer;

	// Use this for initialization
	void Start () {
        timeLeft = TimeSpan.FromSeconds(5);
        timer = FindObjectOfType<Timer>();
        timer.Attach(this);
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(timeLeft.ToString());
		if (TimeSpan.Zero >= timeLeft)
        {
            timer.Detach(this);
            Destroy(this.gameObject);
        }
	}
    public void UpdateTime(TimeSpan timePassed)
    {
        timeLeft -= timePassed;
    }
}
