using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


/*
The Cinemachine Virtual Camera has a post-processing pipeline consisting of several stages. 
We perform this check to see what stage of the camera’s post-processing we’re in. 
If we’re in the “Body” stage then we’re permitted to set the Virtual Camera's position in space.

Halpern, Jared. Developing 2D Games with Unity (p. 137)
*/

public class CameraStabalizer : MonoBehaviour
{

    public float PixelsPerUnit = 32;

    protected void PostPipelineStageCallback(
        CinemachineVirtualCameraBase virtualCameraBase,
        CinemachineCore.Stage stage, ref CameraState state,
        float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            Vector3 pos = state.FinalPosition;
            Vector3 pos2 = new Vector3(Round(pos.x), Round(pos.y), pos.z);
            state.PositionCorrection += pos2 - pos;
        }
    }
    float Round(float x)
    {
        return Mathf.Round(x * PixelsPerUnit) / PixelsPerUnit;
    }
}
