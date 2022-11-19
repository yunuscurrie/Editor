using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject cube;
    public GameObject objManager;
    public Pointer pointer;

    public List<int> tileKeymap;

    public static int width;
    public static int height;
    public static int depth;
    public CubeData[,,] cubeGrid;
    public int w;
    public int h;
    public int d;
    public GameObject Cube;

    public bool editor;
    public int brush;
    public int chosenBrush;
    public GameObject instances;
    public List<GameObject> cubes = new List<GameObject>();
    public List<GameObject> varients = new List<GameObject>();


    void Start()
    {
                pointer = GameObject.Find("Pointer").GetComponent<Pointer>();

        editor = true;
        chosenBrush = 2;
        brush = 0;
        setup();
        gameObject.transform.position = new Vector3(1,1,1);
            GameObject instance = Instantiate(cube, new Vector3(1,1,1),Quaternion.identity);
            cubes.Add(instance);            
 
       
    }
    void Update(){
        if (Input.GetKeyDown("1"))
        {
            nextBrush(1);
        }
        if (Input.GetKeyDown("2"))
        {
            nextBrush(2);
        }
        if (Input.GetKeyDown("3"))
        {
            nextBrush(3);
        }
        if (Input.GetKeyDown("4"))
        {
            nextBrush(4);
        }
        if (Input.GetKeyDown("5"))
        {
            nextBrush(5);
        }
        if (Input.GetKeyDown("0")){
            editor = !editor;
        }
        if (Input.GetKeyDown(KeyCode.E)){
        pointer.EyeDropper();
        }

        

    }

    public bool nextBrush(int key){

        for (int i = 0; i < tileKeymap.Count; i++){
            if (chosenBrush < tileKeymap.Count-1){
                chosenBrush++;
            } else {
                chosenBrush = 0;
            }
            if (tileKeymap[chosenBrush] == key){
                return false;
            }
            
        }
        return true;
    }

    public void setup(){
        width = 9+2;
        height = 9+2;
        depth = 9+2;
        w = width;
        h = height;
        d = depth;
        cubeGrid = new CubeData[width,height,depth];

        for(int x = 0; x < width; x++){
            for(int y = 0; y < height; y++){
                for(int z = 0; z < depth; z++){
                    cubeGrid[x, y, z] =  ScriptableObject.CreateInstance<CubeData>();
                    cubeGrid[x, y, z].init (x,y,z,0);
                }
            }
        }
        cubeGrid[1,1,1].init(1,1,1,2);

    }

    public bool add(int x, int y, int z, int tile){
        if (cubeGrid[x,y,z].getTile() == tile){
            return false;
        }
        cubeGrid[x,y,z].setTile(tile);
        cube.SetActive(true);

         instances = Instantiate(varients[chosenBrush], new Vector3(x,y,z),Quaternion.identity);
        cube.SetActive(false);

        return true;
    }
    public void remove(int x, int y, int z){
       cubeGrid[x, y, z].setTile(0);
        for(int i = cubes.Count-1; i >=0; i--){
            if (cubes[i]){
                                 cubes[i].GetComponent<ObjectScript>().position();

            }
            if(cubes[i] == null){
              cubes.RemoveAt(i);
            }
        }
            
            
    }
    public void addInstance(){
        if (!cubes.Contains(instances)){

                cubes.Add(instances);

        }

    }
}
