using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class UIButtonKeyListener : MonoBehaviour {

    public string inputName;

    private Image sprite;
    private Vector3 startPos;

	// Use this for initialization
	void Start () {
        sprite = GetComponent<Image>();
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton(inputName)) 
            this.transform.position = startPos + Vector3.down * 2f;
        else
            this.transform.position = startPos;
    }
}
