using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ObjectScript ObjectScr;
    public ObjectManager ObjectMan;
    public Pointer point;
    // Start is called before the first frame update
    void Start()
    {
        ObjectMan = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();
    }

    // Update is called once per frame
    void Update()
    {
        point.editor();
        point.editorPos();
        for(int i = 0; i < ObjectMan.cubes.Count; i++){
            if (ObjectMan.cubes[i] != null){
                ObjectMan.cubes[i].GetComponent<ObjectScript>().position();
            }
        }
        ObjectMan.addInstance();

        
    }
    // HEllo
}
