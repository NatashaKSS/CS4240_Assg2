using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_TargetHitScript : MonoBehaviour {

	public AudioClip MusicClip;
	public AudioSource MusicSource;

	// Use this for initialization
	void Start () {
		MusicSource.clip = MusicClip;
	}

	public void Play() {
		MusicSource.Stop();
		MusicSource.Play();
	}

}
