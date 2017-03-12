using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSound : MonoBehaviour {
    AudioSource audSource;
	// Use this for initialization
	void Start () {
        audSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!audSource.isPlaying)
        {
            Destroy(gameObject);
        }
	}
}
