using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour
{

    [SerializeField] float wallDistance = .6f;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsGrounded()
    {

        Vector3 left = new Vector3(transform.position.x - 0.25f, transform.position.y, transform.position.z);
        Vector3 right = new Vector3(transform.position.x + 0.25f, transform.position.y, transform.position.z);

        if (Physics.Raycast(transform.position, Vector3.down, 0.3f) 
            || Physics.Raycast( left, Vector3.down, 0.3f) 
            || Physics.Raycast(right, Vector3.down, 0.3f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsLeftWall() {
        Vector3 bottom = new Vector3(transform.position.x - 0.25f, transform.position.y, transform.position.z);
        Vector3 top = new Vector3(transform.position.x + 0.25f, transform.position.y, transform.position.z);

        if (Physics.Raycast(transform.position, -transform.right, wallDistance) || Physics.Raycast(bottom, -transform.right, wallDistance) || Physics.Raycast(top, -transform.right, wallDistance))
        {
            Debug.Log("Left Wall");
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsRightWall() {
        Vector3 bottom = new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z);
        Vector3 top = new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z);

        if (Physics.Raycast(transform.position, transform.right, wallDistance) || Physics.Raycast(bottom, transform.right, wallDistance) || Physics.Raycast(top, transform.right, wallDistance))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public bool IsBackWall()
    {
        Vector3 topRight = new Vector3(transform.position.x + 0.25f, transform.position.y + 0.25f, transform.position.z);
        Vector3 topLeft = new Vector3(transform.position.x - 0.25f, transform.position.y + 0.25f, transform.position.z);
        Vector3 bottomRight = new Vector3(transform.position.x + 0.25f, transform.position.y - 0.25f, transform.position.z);
        Vector3 bottomLeft = new Vector3(transform.position.x - 0.25f, transform.position.y - 0.25f, transform.position.z);

        if (Physics.Raycast(topRight, -transform.forward, wallDistance) || Physics.Raycast(topLeft, -transform.forward, wallDistance) || Physics.Raycast(bottomRight, -transform.forward, wallDistance) || Physics.Raycast(bottomLeft, -transform.forward, wallDistance))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public bool IsFrontWall()
    {
        Vector3 topRight = new Vector3(transform.position.x + 0.25f, transform.position.y + 0.25f, transform.position.z);
        Vector3 topLeft = new Vector3(transform.position.x - 0.25f, transform.position.y + 0.25f, transform.position.z);
        Vector3 bottomRight = new Vector3(transform.position.x + 0.25f, transform.position.y - 0.25f, transform.position.z);
        Vector3 bottomLeft = new Vector3(transform.position.x - 0.25f, transform.position.y - 0.25f, transform.position.z);

        if (Physics.Raycast(topRight, transform.forward, wallDistance) || Physics.Raycast(topLeft, transform.forward, wallDistance) || Physics.Raycast(bottomRight, transform.forward, wallDistance) || Physics.Raycast(bottomLeft, transform.forward, wallDistance))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

}
