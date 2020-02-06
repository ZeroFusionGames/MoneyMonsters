using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightTimeSlider : MonoBehaviour
{
	public DayNightCycle daynight;
	public Slider slider;
	public float changedTime;
	// Update is called once per frame
	public void OnValueChanged()
	{
		changedTime = slider.value;
		Debug.Log("changedTime");
		daynight._timeOfDay = changedTime;
    }
}
