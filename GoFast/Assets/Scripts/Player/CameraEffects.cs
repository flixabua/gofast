/*
 * written by Jonas hack
 *
 * appies stuff like fov-punch to cameras
 * gets triggered by CameraEffectsMaster
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        if (cam == null) Debug.LogError(name + " could not find a camera");
    }

    public IEnumerator fovPunch(float strength, float duration, AnimationCurve curve)
    {
        float fov = cam.fieldOfView;
        for (float i = 0; i < duration; i += Time.deltaTime)
        {

            cam.fieldOfView = fov + strength * curve.Evaluate(i / duration);
            yield return new WaitForEndOfFrame();
        }

        cam.fieldOfView = fov;
        yield return null;
    }
}
