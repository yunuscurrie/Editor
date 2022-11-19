using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    public int x;
    public int y;
    public int z;
    public int tile;
    public int index;

    public int test;

    public ObjectManager ObjectMan;
    // Start is called before the first frame update
    void Start()
    {

        ObjectMan = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();

       //gameObject.transform.position = new Vector3(gameObject.transform.position.x+1, gameObject.transform.position.y+1, gameObject.transform.position.z);
       gameObject.SetActive(true);
        x = (int)gameObject.transform.position.x;
        y = (int)gameObject.transform.position.y;
        z = (int)gameObject.transform.position.z;


    }

    public void position()
    {
        gameObject.transform.position = new Vector3(x,y,z);
        tile = ObjectMan.cubeGrid[x,y,z].getTile();
        if (tile == 0){

             Destroy(gameObject);

        }
    }
}
