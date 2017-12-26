using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	public Text timeUI;
	private TimeSpan time;
	void Start()
	{
		this.time = TimeSpan.Zero;
	}
	void Update()
	{
		time += TimeSpan.FromSeconds(Time.deltaTime);
		timeUI.text = time.Minutes.ToString() + " : " + time.Seconds.ToString ();
		//Debug.Log (time);
	}
	public TimeSpan getTime(){
		return this.time;
	}
}
