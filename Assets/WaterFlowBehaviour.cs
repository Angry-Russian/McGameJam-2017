using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFlowBehaviour : MonoBehaviour {

    public Material waterTarget;
    public Vector2 delta;
    private Vector2 offset = new Vector2();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        offset += delta * Time.deltaTime;
		waterTarget.SetTextureOffset("_MainTex", offset);
    }
}
