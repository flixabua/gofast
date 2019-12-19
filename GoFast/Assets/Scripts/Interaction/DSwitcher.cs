/*
 * written by Jonas hack
 *
 * manages all dimensions and triggers the shifting
 * 
 */ 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DSwitcher : MonoBehaviour
{

    //Currently does not get reset when respwning. should it?

    //TODO: change colorgrading depending on dimension

    private List<DSwitchable> switchables = new List<DSwitchable>();
    public  Dimension[] dimensions = new Dimension[0];//TODO: make sure they are in the right places
    int currentDimension = 0;

    public string button = "Switch";

    private void Update()
    {
        if (Input.GetButtonDown(button))
        {
            currentDimension++;
            if (currentDimension >= dimensions.Length) currentDimension = 0;
            switchDimension(currentDimension);
        }
    }

    private void Start()
    {
        switchables = GameObject.FindObjectsOfType<DSwitchable>().ToList<DSwitchable>();

        if (dimensions.Length == 0) Debug.LogError("There are no dimensions to shift to");

        switchDimension(0);
    }

    public static Dimension register(DSwitchable switchObject)
    {
        DSwitcher switcher = GameObject.FindObjectOfType<DSwitcher>();//maybe use singelton instead?

        if (switcher != null)
        {
            switcher.switchables.Add(switchObject);
            int i = switchObject.dimensionIndex;
            if (i >= 0 && i < switcher.dimensions.Length) return switcher.dimensions[i];
            else return null;
        }
        else
        {
            Debug.Log(switchObject.name + " could not find a switcher to register to");
            return null;
        }
    }

    public void switchDimension(int dimension)//TODO: enable / disable certain dimensions without affecting the others
    {
        Debug.Log("Switching to " + dimension);

        CameraEffectsMaster.fovPunch(5, 0.5f);

        if (dimension >= 0 && dimension  < dimensions.Length)
        {
            foreach (DSwitchable switchO in switchables)
            {
                switchO.switchTo(dimension);
            }
        }
        else
        {
            Debug.LogWarning("tried to switch to an invalid dimesion");
        }
    }
}
