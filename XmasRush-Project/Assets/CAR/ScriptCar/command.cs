using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class command : MonoBehaviour {
	public AudioClip accelere;
	public AudioClip freine;

	public GameObject iconSpeed;
	public GameObject iconStop;

	AudioSource audioSource;
	// Use this for initialization
	void Start () {
		iconStop.SetActive (false);
		iconSpeed.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey("joystick button 3")){
			AudioSource audio = GetComponent<AudioSource>();
			iconSpeed.SetActive (true);
			iconStop.SetActive (false);

			audio.clip = accelere;
			audio.Play();

		}
		else if (Input.GetKey("joystick button 2")){
			iconSpeed.SetActive (false);
			iconStop.SetActive (true);
			AudioSource audio = GetComponent<AudioSource>();

			audio.clip = freine;
			audio.Play();
		}
	}
}
