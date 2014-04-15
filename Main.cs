using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	public float nextTime_= 0.0f;
	public float timeBetweenBalloons_=2.0f;
	public GameObject balloonPrefab_;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int i = 0;
		if (nextTime_ <= Time.time && i<5) {
			Debug.Log ("Balloon Made");
			Instantiate(balloonPrefab_);
			nextTime_ = Time.time + timeBetweenBalloons_;
			i++;
		}
	}
}
