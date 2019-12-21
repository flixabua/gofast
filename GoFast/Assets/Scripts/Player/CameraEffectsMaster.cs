/*
 * written by Jonas hack
 *
 * triggers stuff like fov-punch to cameras
 * works with "CameraEffects"
 * 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraEffectsMaster : MonoBehaviour
{
    public static CameraEffectsMaster instance;
    public static CameraEffects[] effects = new CameraEffects[0];
    public AnimationCurve fovPunchCurve = new AnimationCurve();

    private List<PostProcessVolume> ppVolumes = new List<PostProcessVolume>();


    void Awake()//gets called before start -> there is an instacne for all the other stuff to register to
    {
        reload();
    }   

    public static void fovPunch(float strength, float duration)
    {
        //Debug.Log(" fov punch");
        if (instance != null) instance.applyFovPunch(strength, duration);
        else Debug.LogWarning("Attempted fov punch, but there was no instance of the master");
    }

    public static int addVolume(PostProcessProfile profile)
    {
        if (instance != null)
        {
            PostProcessVolume volume = instance.gameObject.AddComponent<PostProcessVolume>();
            volume.profile = profile;
            volume.isGlobal = true;
            volume.priority = 1;
            volume.weight = 0;

            instance.ppVolumes.Add(volume);
            return instance.ppVolumes.Count - 1;
        }
        else
        {
            Debug.LogWarning("Attempted to add PP-Volume, but there was no instance of the master");
            return -1;
        }
    }

    public static void setVolumeweight(int index, float weigt)//WHY DO THEY NOT AFFECT THE SCENE ?????? AHHHH
    {
        if (instance != null)
        {
            if (index >= 0 && index < instance.ppVolumes.Count)
            {
                instance.ppVolumes[index].weight = weigt;
            }
            else Debug.LogWarning("Attempted to set volume weight, but the index was out of bounds: " + index + ", max allowed: " + instance.ppVolumes.Count);
        }
        else Debug.LogWarning("Attempted to set volume weight, but there was no instance of the master");
    }

    /*
    public static void changeColor(Color color)
    {
        if (instance != null) instance.applyChangeColor(color);
        else Debug.LogWarning("Attempted color change, but there was no instance of the master");
    }
    
    private void applyChangeColor(Color color)//FIXME: doesnt update and does not affect gameplay at all
    {
        Debug.Log("Change Color");
        ColorParameter param = new ColorParameter();
        param.value = color;
        param.overrideState = true;
        colorGrading.colorFilter = param;
        //ppVolume.profile.settings.Clear();
        //ppVolume.profile.settings.Add(colorGrading);
    }
    */
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

       
        if (this == instance)
        {
           /* 
            GameObject gObject = new GameObject("dimensionPostprocessVolume");
            gObject.transform.parent = transform;
            gObject.layer = 8;//post processing
            ppVolume = gObject.AddComponent<PostProcessVolume>();
            colorGrading = ppVolume.profile.AddSettings<ColorGrading>();
            ppVolume.isGlobal = true;
            ppVolume.priority = 2;
            ppVolume.weight = 1;
            */
        }
    }
}
