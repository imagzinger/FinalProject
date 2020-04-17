using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LookingDirection : MonoBehaviour
{
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    public float yaw = 0.0f;
    public float pitch = 0.0f;

    public bool paused = false;

    [SerializeField] Transform player;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            yaw += speedH * Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");

            player.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
    }

    public void SetPause(bool val)
    {
        paused = val;
    }

}
