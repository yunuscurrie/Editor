using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public int mouseX;
    public int mouseY;
    public int mouseZ;
    public int x;
    public int y;
    public int tile;

    public float test1;
    public float test2;
    public float test3;

    public int z;

    public Camera mainCamera;
    public ObjectManager ObjectMan;
    public bool hide;
    public bool prev;
    public bool prev2;

    public int[] prevCoords;

    public GameObject[] varients;

    public GameManager gameMan;

    public int tileBrush;
    void Start(){
        gameMan = GameObject.Find("GameManager").GetComponent<GameManager>();

        ObjectMan = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();
        mainCamera = Camera.main;
        tileBrush = ObjectMan.chosenBrush;
        gameMan.point = gameObject.GetComponent<Pointer>();
        ObjectMan.pointer = gameObject.GetComponent<Pointer>();
        prevCoords = new int[3];


    }
    public void EyeDropper(){
            getMouseTile();
            if(tile > 0){
            ObjectMan.chosenBrush = tile;
            }
            
    }
    public void editorPos(){
    editorBrush();
        if (ObjectMan.brush != -1){
            if (!ObjectMan.editor){
              gameObject.SetActive(false);
            }
        }
        if (!hide){
            gameObject.SetActive(false);
        }
       gameObject.transform.rotation = Quaternion.identity;
       gameObject.transform.position = new Vector3(mouseX,mouseY,mouseZ);

        //costume
    }
    public bool editorBrush(){
        if (!ObjectMan.editor || ObjectMan.brush == -1 || Input.GetMouseButton(0) || Input.GetMouseButton(1)){
            gameObject.SetActive(false);
            return false;
        }
        getMouseTile();
       gameObject.SetActive(true);
        return true;

    }
    public void getMouseTile(){
        gameObject.SetActive(false);
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit)){

           

            mouseX = (int)(raycastHit.point.x + 0.5f);
            mouseY = (int)(raycastHit.point.y + 0.5f);
            mouseZ = (int)(raycastHit.point.z + 0.5f);
        
            x = (int)(raycastHit.point.x + 0.5f-0.001f);
            y = (int)(raycastHit.point.y + 0.5f-0.001f);
            z = (int)(raycastHit.point.z + 0.5f-0.001f);

            test1 = raycastHit.point.x + 0.5f;
            test2 = raycastHit.point.y + 0.5f;
            test3 = raycastHit.point.z + 0.5f;

            if (ObjectMan.cubeGrid[mouseX,mouseY,mouseZ].getTile() != 0){
                int temp = mouseX;
                mouseX = x;
                x = temp;
                temp = mouseY;
                mouseY = y;
                y = temp;
                temp = mouseZ;
                mouseZ = z;
                z = temp;
            }

            tile = ObjectMan.cubeGrid[x,y,z].getTile();
        }
                
                if ((raycastHit.point.x + 0.5f) != 0.5){
                    hide = true;
                }

    }
    public bool editor(){
        if (tileBrush != ObjectMan.chosenBrush){
            tileBrush = ObjectMan.chosenBrush;
            Instantiate(varients[tileBrush], new Vector3(x,y,z),Quaternion.identity);
            Destroy(gameObject);
        }
    
        hide = false;
        getMouseTile();
        if (!hide){
            prev = false;
            return false;
        }
        if (!ObjectMan.editor){
            prev = false;
            return false;
        }
        if (!(Input.GetMouseButton(0) || Input.GetMouseButton(1))){
            ObjectMan.brush = 0;
            prev = false;
            return false;
        }
        if (ObjectMan.brush == 0){
            if (tile == ObjectMan.chosenBrush){
                ObjectMan.brush = -1;
                hide = true;
            } else {
                ObjectMan.brush = ObjectMan.chosenBrush;
            }
        }
        if (Input.GetMouseButton(1)){
            ObjectMan.brush = -1;
        }
        
            if(ObjectMan.brush == -1 &&Input.GetMouseButton(1)){
                if(prevCoords[0] != mouseX || prevCoords[1] != mouseY || prevCoords[2] != mouseZ){
                    prev = false;
                }
            if (!prev){
                    prev = true;

                    ObjectMan.remove(x, y, z);
                    getMouseTile();
                    prevCoords = new int[] {x, y, z};
                }
        } else {
            if(mouseX>0 && mouseY>0 && mouseZ>0 && mouseX < ObjectMan.w-1 && mouseY < ObjectMan.h-1 && mouseZ < ObjectMan.d-1){
            if(prevCoords[0] != mouseX || prevCoords[1] != mouseY || prevCoords[2] != mouseZ || prevCoords[3] != x || prevCoords[4] != y || prevCoords[5] != z){
                prev = false;
                }
            if (!prev){
                    ObjectMan.add(mouseX, mouseY, mouseZ, ObjectMan.brush);
                    getMouseTile();
                    prevCoords = new int[] {mouseX, mouseY, mouseZ, x, y, z};

                }
                prev = true;
            }
        }
        
        hide = false;
        
        return true;
    }
}
