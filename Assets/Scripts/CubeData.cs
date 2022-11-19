using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeData : ScriptableObject
{
    private int x;
    private int y;
    private int z;
    private int tile;
    private int index;

    public void init(int x, int y, int z, int tile){
        this.x = x;
        this.y = y;
        this.z = z;
        this.tile = tile;
    }
    public int getX(){
        return x;
    }
    public int getY(){
        return y;
    }
     public int getZ(){
        return z;
    }
     public int getTile(){
        return tile;
    }
     public int getIndex(){
        return index;
    }
    public void setX(int x){
        this.x = x;
    }
    public void setY(int y){
        this.y = y;
    }
     public void setZ(int z){
        this.z = z;
    }
     public void setTile(int tile){
        this.tile = tile;
    }
     public void setIndex(int index){
        this.index = index;
    }
}
