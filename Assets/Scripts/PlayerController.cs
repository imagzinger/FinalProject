﻿using UnityEngine;
using System;
using System.Collections.Specialized;

public class PlayerController : MonoBehaviour
{
	public Rigidbody rb;
	public float degrees;
	public float zOffset;
	public float xOffset;
    public int kills = 0;
    PhysicsController physicsController;
    [SerializeField] ObjectiveScript os;
    [SerializeField] GameObject crossHair;
    [SerializeField] GameObject scopedCross;
    [SerializeField] GameObject gunObj;
    [SerializeField] GameObject endScene;
    [SerializeField] LevelManager levelManager;
    [SerializeField] float jumpForce;
    Gun gunScript;
    Camera camera;
	public float health = 500.0f;
	float speed = 13f;
	public bool hasObjective = false;
    bool isCrouched = false;
    int characterClass;
    GameObject gameManager;
    //[SerializeField] float eulerAngX;
    ////[SerializeField] float eulerAngY;
    [SerializeField] float scroll = 0;
    [SerializeField] int sensitiviy = 75;
    void Start()
    {
        physicsController = GetComponent<PhysicsController>();
        rb = GetComponent<Rigidbody>();
        camera = Camera.main;
        gameManager = GameObject.FindWithTag("GameController");
        characterClass = gameManager.GetComponent<GameManager>().GetClass();
        gunScript = camera.GetComponent<Gun>();
        if (characterClass == 0) {
            characterClass = 1;
        }
        //characterClass = 3;
        if (characterClass == 1) {
            health = 500f;
            speed = 13f;
            gunScript.ammo = 0;
            gunScript.initAmmo = 15;
            gunScript.damage = 35f;
        }
        else if (characterClass == 2) {
            health = 800f;
            speed = 7f;
            gunScript.ammo = 0;
            gunScript.initAmmo = 2;
            gunScript.recoilTime = .15f;
            gunScript.recoilPower = .8f;
            gunScript.damage = 80f;
            gunScript.range = 100f;
        }
        else if (characterClass == 3)// sniper
        {
            health = 300f;
            speed = 16f;
            gunScript.ammo = 0;
            gunScript.initAmmo = 1;
            gunScript.recoilTime = .10f;
            gunScript.recoilPower = 5f;
            gunScript.damage = 150f;
            gunScript.range = 1000f;
        }
    }

    void Update()
    {
        //eulerAngX = transform.localRotation.eulerAngles.x;
        //eulerAngY = transform.localRotation.eulerAngles.y;
        //eulerAngZ = transform.localRotation.eulerAngles.z;// transform.localEulerAngles.z;
        degrees = transform.localRotation.eulerAngles.y;
        zOffset = Time.deltaTime * speed * (float)Math.Cos((degrees) / 180 * Math.PI);
        xOffset =  Time.deltaTime *speed * (float)Math.Sin((degrees) / 180 * Math.PI);
        scroll = Input.GetAxis("Mouse ScrollWheel");
        camera.fieldOfView -= scroll * sensitiviy;
        //Debug.Log("X Offset: " + xOffset + ", Z Offset: " + zOffset);
        // Debug.Log("forward: " + transform.forward);

        //crouch
        if (Input.GetKey(KeyCode.LeftControl)) {
            if (!isCrouched)
            {
                isCrouched = true;
                camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y - 1f, camera.transform.position.z);
                gunScript.recoilPower -= (gunScript.recoilPower * 2 / 3);
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftControl)) {
            if (isCrouched) {
                isCrouched = false;
                camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y + 1f, camera.transform.position.z);
                gunScript.recoilPower += (gunScript.recoilPower * 2 / 3);
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (physicsController.IsFrontWall())
            {
                xOffset = 0;
                zOffset = 0;
            }
   
            transform.position += new Vector3(xOffset, 0, zOffset);
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (physicsController.IsBackWall())
            {
                xOffset = 0;
                zOffset = 0;
            }
            transform.position += new Vector3(-xOffset, 0, -zOffset);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (physicsController.IsRightWall())
            {
                xOffset = 0;
                zOffset = 0;
            }
            transform.position += new Vector3(zOffset, 0, -xOffset);
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (physicsController.IsLeftWall())
            {
                xOffset = 0;
                zOffset = 0;
            }
            transform.position += new Vector3(-zOffset, 0, xOffset);
        }

		if (Input.GetKeyDown(KeyCode.Space))
		{
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		}

        if (camera.fieldOfView < 30)
        {
            gunObj.SetActive(false);
            crossHair.SetActive(false);
            scopedCross.SetActive(true);
        }
        else
        {
            gunObj.SetActive(true);
            crossHair.SetActive(true);
            scopedCross.SetActive(false);
            if (camera.fieldOfView > 60)
                camera.fieldOfView = 60;
        }

        if (health <= 0)
        {
            levelManager.GameOver();   
        }
        //jump struggling...
        rb.AddForce(Vector3.down * 10f, ForceMode.VelocityChange);
        rb.velocity = Vector3.zero;
        hasObjective = os.isTaken;
	}
   
}
