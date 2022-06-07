using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float m_vertical;
    public float m_horizontal;
    public bool m_handbrake;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void Keybord()
    {
        m_vertical = Input.GetAxis("Vertical");
        m_horizontal = Input.GetAxis("Horizontal");
        m_handbrake = (Input.GetAxis("Jump") != 0)? true: false;
    }
}
