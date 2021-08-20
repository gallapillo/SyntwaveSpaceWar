using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class Thruster : MonoBehaviour
{
    //TrailRenderer trail;
    Light thrusterLight;

    private void Awake()
    {
        //trail = GetComponent<TrailRenderer>();
        thrusterLight = GetComponent<Light>();
    }

    void Start()
    {
        // trail.enabled = false;
        // thrusterLight.enabled = false;
        thrusterLight.intensity = 0;
    }

    /*public void Activate(bool activate = true)
    {
        if (activate)
        {
            trail.enabled = true;
            thrusterLight.enabled = true;
            // effect
            // sounds
        }
        else
        {
            trail.enabled = false;
            thrusterLight.enabled = false;
            // turn off
        }
    }*/

    public void Intensity(float inten, int mode)
    {
        if (mode > 0)
        {
            thrusterLight.intensity = inten * 255f;
            thrusterLight.enabled = true;
        }
        else
        {
            thrusterLight.intensity = inten * 255f;
            thrusterLight.enabled = false;
        }
    }

}
