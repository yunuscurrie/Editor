using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    public float speed;
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
        z = gameObject.transform.position.z;
        if (Input.GetKey(KeyCode.W)){
            gameObject.transform.position = new Vector3(x,y+(speed*Time.deltaTime),z);
        }
        if (Input.GetKey(KeyCode.S)){
            gameObject.transform.position = new Vector3(x,y-(speed*Time.deltaTime),z);
        }
        if (Input.GetKey(KeyCode.A)){
            gameObject.transform.Rotate(0f,rotateSpeed*Time.deltaTime, 0f, Space.World);
        }
        if (Input.GetKey(KeyCode.D)){
            gameObject.transform.Rotate(0f,-rotateSpeed*Time.deltaTime, 0f, Space.World);
        }
        if (Input.GetKey("up")){
            gameObject.transform.position = new Vector3(x+(speed*Time.deltaTime),y,z);
        }
        if (Input.GetKey("down")){
            gameObject.transform.position = new Vector3(x-(speed*Time.deltaTime),y,z);
        }
        if (Input.GetKey("left")){
            gameObject.transform.position = new Vector3(x,y,z-(speed*Time.deltaTime));
        }
        if (Input.GetKey("right")){
            gameObject.transform.position = new Vector3(x,y,z+(speed*Time.deltaTime));
        }
    }
}
