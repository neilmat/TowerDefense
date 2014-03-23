﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class MakeGrid : MonoBehaviour {
	
	public Transform squarePrefab;
	public int width = 20;
	public int length = 20;
	public float heightPos = 0;
	public float xPos = 0;
	public float zPos = 0;
	public static Transform[,] board;
	
	void Start () {
		SetUpBoard();
	}
	
	void Update(){
			
	}
	
	string sayName(Transform t){
		return "(" + t.position.x + ", " + heightPos + ", " + t.position.z + ")";
	}
	
	void SetUpBoard(){
		board = new Transform[width, length];
		for (int x = 0; x < width; x++) {
			for (int z = 0; z < length; z++) {
				Transform newSquare;
				newSquare = (Transform)Instantiate(squarePrefab, new Vector3 (x + xPos, heightPos, z + zPos), Quaternion.identity);
				newSquare.parent = transform;	//puts grid as parent of gameSquare
				newSquare.name = sayName(newSquare);
				//newSquare.GetComponent<terrainTowerScript>.baseEnergy = 10;
				//newSquare.GetComponent<terrainTowerScript>.baseRegen = 1;
				board[x, z] = newSquare;		//note that this array is x by z so layout (column, row) instead of (row, column)
			}
		}
	}	
	
	public Vector3 snapHeight(Vector3 temp){
		temp.y = heightPos + 1;
		return temp;
	}
	public Vector3 snap(Vector3 temp){
		float intersectionOffset = 0.0f;

		temp = snapHeight(temp);
		if(temp.x < xPos - intersectionOffset){
			temp.x = xPos - intersectionOffset;
		}
		else if(temp.x > xPos + width - 1 + intersectionOffset){
			temp.x = xPos + width - 1 + intersectionOffset;
		}
		if(temp.z < zPos - intersectionOffset){
			temp.z = zPos - intersectionOffset;
		}
		else if(temp.z > zPos + length - 1 + intersectionOffset){
			temp.z = zPos + length - 1 + intersectionOffset;
		}
		float offset = temp.x - xPos - intersectionOffset;
		offset = Mathf.Round(offset);
		temp.x = offset + xPos + intersectionOffset;
		
		offset = temp.z - zPos - intersectionOffset;
		offset = Mathf.Round(offset);
		temp.z = offset + zPos + intersectionOffset;
		
		return temp;
	}
}

