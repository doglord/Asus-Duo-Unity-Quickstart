using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scans all connected displays and activates 
/// Tested in Unity 2019.4.12f1 && briefly in 2020.1.8
/// </summary>
public class ASUSMultiDisplayActivation : MonoBehaviour
{
    // i believe this ratio is consistent for both possible resolutions
    const float lowerScreenRatio = 1920 / 550;

    public Camera upperCam;
    public Camera lowerCam;

    // this assumes the laptop's main monitor is the default, may need tweaking for different monitor setups
    void Awake()
    {
        var i = 0;
        foreach (var item in Display.displays)
        {
            // activate main display (0) & lower display 
            // (index can vary with other displays connected)
            if ((lowerScreenRatio == item.renderingWidth / item.renderingHeight) || i == 0)
            {
                //x += $"Display {i}: {item.renderingWidth} X {item.renderingHeight}\n";

                item.Activate();

                // forgoing this code will result in the lower screen being black
                if (i == 0)
                {
                    //x += $"Setting upper target to display {i}\n";
                    upperCam.targetDisplay = i;
                }
                else
                {
                    //x += $"Setting lower target to display {i}\n";
                    lowerCam.targetDisplay = i;
                }
            }
            i++;
        }

    }
}
