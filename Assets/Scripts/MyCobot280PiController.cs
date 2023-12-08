using System;
using System.Collections;
using System.Collections.Generic;
using RosMessageTypes.Sensor;
using Unity.Robotics.ROSTCPConnector;
using Unity.VisualScripting;
using UnityEngine;

public class MyCobot280PiController : MonoBehaviour
{
    public ArticulationBody joint2;
    public ArticulationBody joint3;
    public ArticulationBody joint4;
    public ArticulationBody joint5;
    public ArticulationBody joint6;
    public ArticulationBody joint6Flange;
    public ArticulationBody leftGripper;
    public ArticulationBody rightGripper;

    private ArticulationBody[] joint;
    private ROSConnection ros;

    // Start is called before the first frame update
    void Start()
    {
        // ros = ROSConnection.GetOrCreateInstance();
        // ros.Subscribe<JointStateMsg>("/joint_states", Callback);
        //
        // joint = new ArticulationBody[6];
        // joint[0] = joint2;
        // joint[1] = joint3;
        // joint[2] = joint4;
        // joint[3] = joint5;
        // joint[4] = joint6;
        // joint[5] = joint6Flange;
        ArticulationDrive drive = leftGripper.zDrive;
        drive.targetVelocity = 1;
        leftGripper.zDrive = drive;
    }
    void Callback(JointStateMsg msg)
    {
        for (int i = 0; i < 6; i++)
        {
            ArticulationDrive aDrive = joint[i].xDrive;
            aDrive.target = Mathf.Rad2Deg * (float)msg.position[i];
            joint[i].xDrive = aDrive;
            Debug.Log(aDrive.target);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        // 다른 개체의 Collider 컴포넌트에 액세스
        Collider otherCollider = collision.collider;
        // 콜라이더가 트리거 콜라이더인지 확인
        if(otherCollider.isTrigger)
        {
            Debug.Log("트리거 콜라이더와의 충돌이 감지되었습니다!");
        }
        else
        {
            Debug.Log("물리 충돌체와의 충돌이 감지되었습니다!");
        }
    }
}
