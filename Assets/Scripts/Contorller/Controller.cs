using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Controller : MonoBehaviour
{
    internal enum DriveType
    {
        FrontWheelType,
        RearWheelType,
        AlltWheelType,
    }

    private DriveType drive;

    public InputManager m_InputManager;
    //車のタイヤ生成
    public WheelCollider[] m_wheels = new WheelCollider[4];
    //車のメッシュ生成
    public GameObject[] m_wheelMesh = new GameObject[4];
    //車のトルク(回転数)
    public float m_motorTorque = 200;
    //車の最大ステアリング
    public float m_steeringMax = 4;


    void Start()
    {
        GatObjects();
    }

    void Update()
    {
        //車のタイヤのアニメーション
        animateWheels();
        //車を動かす
        MoveVehicle();
        //車のタイヤの角度
        SteeerVehicle();
    }

    private void FixedUpdate()
    {
     
    }

    /// <summary>
    /// 車を動かす
    /// </summary>
    private void MoveVehicle()
    {
        if (drive == DriveType.AlltWheelType)
        {
            for (int i = 0; i < m_wheels.Length; i++)
            {
                m_wheels[i].motorTorque = m_InputManager.m_vertical * (m_motorTorque / 4);
            }
        }

        if (drive == DriveType.RearWheelType)
        {
            for (int i = 2; i < m_wheels.Length; i++)
            {
                m_wheels[i].motorTorque = m_InputManager.m_vertical * (m_motorTorque / 2);
            }
        }
        else
        {
            for (int i = 0; i < m_wheels.Length - 2; i++)
            {
                m_wheels[i].motorTorque = m_InputManager.m_vertical * (m_motorTorque / 2);
            }
        }

        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    for (int i = 0; i < wheels.Length; i++)
        //    {
        //        wheels[i].motorTorque = torque;
        //    }
        //}

        //if (Input.GetAxis("Horizontal") != 0)
        //{
        //    for (int i = 0; i < wheels.Length - 2; i++)
        //    {
        //        wheels[i].steerAngle = Input.GetAxis("Horizontal") * steeringMax;
        //    }
        //}
        //else
        //{
        //    for (int i = 0; i < wheels.Length - 2; i++)
        //    {
        //        wheels[i].steerAngle = 0;
        //    }
        //}
    }

    private void SteeerVehicle ()
    {
        for (int i = 0; i < m_wheels.Length - 2; i++)
        {
            m_wheels[i].steerAngle = m_InputManager.m_horizontal * m_steeringMax;
        }
    } 

    /// <summary>
    /// 車のタイヤのアニメーション
    /// /// </summary>
    void animateWheels()
    {
        Vector3 wheelPostion = Vector3.zero;
        Quaternion wheelRotation = Quaternion.identity;
        for (int i = 0; i < 4; i++)
        {
            m_wheels[i].GetWorldPose(out wheelPostion, out wheelRotation);
            m_wheelMesh[i].transform.position = wheelPostion;
            m_wheelMesh[i].transform.rotation = wheelRotation;

        }
    }

    private void GatObjects()
    {
        m_InputManager = GetComponent<InputManager>();
    }
}

