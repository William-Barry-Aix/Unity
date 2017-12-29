using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public List<ITimeable> timeables;
	private Text timeUI;
    private TimeSpan time;
	void Start()
	{
        this.timeUI = GetComponent<Text>();
		this.time = TimeSpan.Zero;
        this.timeables = new List<ITimeable>();
    }
    void Update()
    {
        TimeSpan timePassed = TimeSpan.FromSeconds(Time.deltaTime);
        time += timePassed;
        timeUI.text = time.Minutes.ToString() + " : " + time.Seconds.ToString();
        foreach (ITimeable timeable in timeables)
        {
            timeable.UpdateTime(timePassed);
        }
        
    }	
    public void Attach(ITimeable timeable)
    {
        this.timeables.Add(timeable);
    }
    public void Detach(ITimeable timeable)
    {
        this.timeables.Remove(timeable);
    }
}
