using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContorller : MonoBehaviour
{
    public GameObject Player;
    public GameObject child;
    public float speed;

    void Start()
    {
        Player  = GameObject.FindGameObjectWithTag("Player");
        child = Player.transform.Find("camera constraint").gameObject;
    }

    void Update()
    {
        Follow();
    }

    void Follow()
    {
        gameObject.transform.position = Vector3.Lerp(transform.position, Player.transform.position, Time.deltaTime * speed );
        gameObject.transform.LookAt(Player.gameObject.transform.position);
    }
    void BoostFOV()
    {

    }
}
