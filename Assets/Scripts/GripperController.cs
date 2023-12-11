using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripperController : MonoBehaviour
{
    public ArticulationBody left;
    public ArticulationBody right;
    public float pickLimit = 0.5f;
    public float placeLimit = 0.5f;

    public void OnPickButton()
    {
        ArticulationDrive leftDrive = left.xDrive;
        ArticulationDrive rightDrive = right.xDrive;

        leftDrive.target = -pickLimit;
        rightDrive.target = pickLimit;

        left.xDrive = leftDrive;
        right.xDrive = rightDrive;
    }

    public void OnPlaceButton()
    {
        ArticulationDrive leftDrive = left.xDrive;
        ArticulationDrive rightDrive = right.xDrive;

        leftDrive.target = placeLimit;
        rightDrive.target = -placeLimit;

        left.xDrive = leftDrive;
        right.xDrive = rightDrive;
    }
}
