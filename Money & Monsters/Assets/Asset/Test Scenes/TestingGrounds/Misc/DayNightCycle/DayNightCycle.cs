using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
	[Header("Time")]
	[Tooltip("Day Length in Minutes")]
	[SerializeField]
	private float _targetDayLength = 0.5f; //length of day in mins
	public float targetDayLength
	{
		get
		{
			return _targetDayLength;
		}
	}
	[SerializeField]
	[Range(0f, 1f)]
	public float _timeOfDay; //tracks the days passed
	public float timeOfDay
	{
		get
		{
			return _timeOfDay;
		}
	}
	[SerializeField]
	private float _dayNumber = 0;
	public float dayNumber
	{
		get
		{
			return _dayNumber;
		}
	}
	[SerializeField]
	private float _yearNumber = 0;
	public float yearNumber
	{
		get
		{
			return _yearNumber;
		}
	}
	private float _timeScale = 100f;
	[SerializeField]
	private float _yearLength = 0;
	public float yearLength
	{
		get
		{
			return _yearLength;
		}
	}
	public bool pause = false;
	[SerializeField]
	private AnimationCurve timeCurve;
	private float timeCurveNormalization;

	[Header("Sun Light")]
	[SerializeField]
	private Transform dailyRotation;
	[SerializeField]
	private Light sun;
	private float sunIntensity;
	[SerializeField]
	private float sunBaseIntensity = 1f;
	[SerializeField]
	private float sunVariation = 1.5f;
	[SerializeField]
	private Gradient sunColour;

	

	[Header("Seasonal Variable")]
	[SerializeField]
	private Transform sunSeasonalRotation;
	[SerializeField]
	[Range(-45f, 45f)]
	private float maxSeasonalTilt;

	private void Start()
	{
		NormaliseTimeCurve();
	}

	private void Update()
	{
		if(!pause)
		{
			UpdateTimeScale();
			UpdateTime();
		}
		AdjustSunRotation();
		SunIntensity();
		AdjustColour();
	}



	private void UpdateTimeScale()
	{
		_timeScale = 24 / (targetDayLength / 60);
		_timeScale *= timeCurve.Evaluate(timeOfDay); //changes timescale based on time curve
		_timeScale /= timeCurveNormalization; //keeps day length at target value
	}

	private void UpdateTime()
	{
		_timeOfDay += Time.deltaTime * _timeScale / 86400; //seconds in a day
		if(timeOfDay > 1)//new day
		{
			_dayNumber++;
			_timeOfDay -= 1;

			if(_dayNumber > _yearLength)//new year
			{
				_yearNumber++;
				_dayNumber = 0;
			}
		}
	}

	private void NormaliseTimeCurve()
	{
		float stepSize = 0.1f;
		int numberSteps = Mathf.FloorToInt(1f / stepSize);
		float curveTotal = 0;
		for (int i = 0; i < numberSteps; i++)
		{
			curveTotal += timeCurve.Evaluate(i * stepSize);

		}

		timeCurveNormalization = curveTotal / numberSteps;
	}

	//rotates the sun daily (and seasonally)
	private void AdjustSunRotation()
	{
		float sunAngle = timeOfDay * 360f;
		dailyRotation.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, sunAngle));

		float seasonalAngle = -maxSeasonalTilt * Mathf.Cos(dayNumber / _yearLength * Mathf.PI);
		sunSeasonalRotation.localRotation = Quaternion.Euler(new Vector3(seasonalAngle, 0f, 0f));
	}

	private void SunIntensity()
	{
		sunIntensity = Vector3.Dot(sun.transform.forward, Vector3.down);
		sunIntensity = Mathf.Clamp01(sunIntensity);

		sun.intensity = sunIntensity * sunVariation + sunBaseIntensity;
	}

	private void AdjustColour()
	{
		sun.color = sunColour.Evaluate(sunIntensity);
		
	}
}
