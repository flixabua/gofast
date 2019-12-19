/*
 * written by Jonas hack
 *
 * triggers stuff like fov-punch to cameras
 * works with "CameraEffects"
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffectsMaster : MonoBehaviour
{
    public static CameraEffectsMaster instance;
    public static CameraEffects[] effects = new CameraEffects[0];
    public AnimationCurve fovPunchCurve = new AnimationCurve();

    // Start is called before the first frame update
    void Start()
    {
        reload();
    }   

    public static void fovPunch(float strength, float duration)
    {
        Debug.Log(" fov punch");
        if (instance != null) instance.applyFovPunch(strength, duration);
        else Debug.LogWarning("Attempted fov punch, but there was no instance of the master");
    }

    public void applyFovPunch(float strength, float duration)
    {
        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].StartCoroutine(effects[i].fovPunch(strength, duration, fovPunchCurve));
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        reload();
    }

    public void reload()
    {
        if (instance == null) instance = this;
        else Destroy(this);

        effects = GameObject.FindObjectsOfType<CameraEffects>();
    }
}
