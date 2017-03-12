using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class UIButtonKeyListener : MonoBehaviour {

    public string inputName;

    private Image sprite;

	// Use this for initialization
	void Start () {
        sprite = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown(inputName)) 
            transform.Translate(Vector3.down * 2f);

        if(Input.GetButtonUp(inputName))
            transform.Translate(Vector3.up * 2f);

    }
}
