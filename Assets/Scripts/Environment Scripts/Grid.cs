using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid {
    // Start is called before the first frame update
    private int width; 
    private int height; 
    private int[,] gridArray; 


    public Grid(int width, int height){
        this.width = width;
        this.height = height; 

        gridArray = new int[width, height];
    }


}
