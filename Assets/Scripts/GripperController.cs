using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripperController : MonoBehaviour
{
    public ArticulationBody left;
    public ArticulationBody right;
    public float pickLimit = 0.01f;
    public float placeLimit = 0.01f;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            OnPickButton();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            OnPlaceButton();
        }
    }
}
