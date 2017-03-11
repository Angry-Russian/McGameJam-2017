using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class MoneyBar : MonoBehaviour {

    public bool active = false;
    private Image c;
    public uint hz = 60;

    public float min = 0;
    public float max = 100;

    private float _fill = 5;
    private float modTime = 0;
    public float fill {
        get {
            return _fill;
        }

        set {
            modTime = Time.timeSinceLevelLoad;
            _fill = value;
        }
    }

    public Image progressBar;
    public bool reverse;
    public float transitionSpeed = 0.2f;

    public ColorVariation pulseColor;

    public enum ColorVariation {
        Alpha, Red, Green, Blue
    };

    private float phase = 0;
    private Color startColor;


	// Use this for initialization
	void Start () {

        c = GetComponent<Image>();

        startColor = new Color {
            r = c.color.r,
            g = c.color.g,
            b = c.color.b,
            a = c.color.a
        };

        phase = 0;// getColorPhase(c.color, pulseColor);
        
	}
	
	// Update is called once per frame
	void Update () {

        if (active) {
            c.color = setColorPhase(c.color, pulseColor, phase);
            phase += Time.deltaTime * hz/60 * Mathf.PI * 2;
        }

        float progress = (fill - min) / (max - min);
        if (reverse) progress = 1 - progress;
        progress = Mathf.Min((Time.timeSinceLevelLoad - modTime) / transitionSpeed, 1f);

        progressBar.transform.localScale = new Vector3(progress, 1, 1);


	}


    private float getColorPhase(Color oc, ColorVariation c) {
        float phase = 0;

        switch (c) {
            case ColorVariation.Alpha: phase = oc.a; break;
            case ColorVariation.Red: phase = oc.r; break;
            case ColorVariation.Green: phase = oc.g; break;
            case ColorVariation.Blue: phase = oc.b; break;
            default: break;
        }

        return Mathf.Asin(phase);
    }

    private Color setColorPhase(Color oc, ColorVariation c, float val) {

        Color col = new Color(1f, 1f, 1f);
        float v = Mathf.Sin(val) / 4 + 0.75f;

        if (c != ColorVariation.Alpha) col.a = startColor.a * Mathf.Cos(v);
        if (c != ColorVariation.Red) col.r = startColor.r * Mathf.Cos(v);
        if (c != ColorVariation.Green) col.g = startColor.g * Mathf.Cos(v);
        if (c != ColorVariation.Blue) col.b = startColor.b * Mathf.Cos(v);

        return col;
    }
}
