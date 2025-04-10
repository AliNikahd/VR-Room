using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Led : MonoBehaviour {

    public enum State  {
        On,
        Off,
        Flashing,
        Manual
    }

    public State state = State.Flashing;
    public float frequency = 1.0f;

    [Range(0.0f, 1.0f)]
    public float intensity;

    MeshRenderer mr;
    Color emissionColor;
    float t;

    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
        emissionColor = mr.material.GetColor("_EmissionColor");
        t = 1.0f;
    }

    private void Update()
    {
        if (state == State.On)
        {
            mr.material.SetColor("_EmissionColor", emissionColor);
            t = 0;
            intensity = 1.0f;
        }
        else if (state == State.Off)
        {
            mr.material.SetColor("_EmissionColor", Color.black);
            t = 0;
            intensity = 0.0f;
        }
        else if (state == State.Flashing)
        {
            intensity = 0.5f + 0.5f * Mathf.Sin(2 * Mathf.PI * frequency * t);
            Color newColor = Color.Lerp(Color.black, emissionColor, intensity);
            mr.material.SetColor("_EmissionColor", newColor);
            t += Time.deltaTime;
        }
        else if (state == State.Manual) {
            Color newColor = Color.Lerp(Color.black, emissionColor, intensity);
            mr.material.SetColor("_EmissionColor", newColor);
            t += Time.deltaTime;
        }
    }

    public void Flip() {
        if (state == State.Off)
            state = State.On;
        else
            state = State.Off;
    }

}
