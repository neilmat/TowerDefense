using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class MakeGrid : MonoBehaviour {
	
	public Transform squarePrefab;
	public int width = 20;
	public int length = 20;
	public float heightPos = 0;
	public float xPos = 0;
	public float yPos = 0;
	public static Transform[,] board;
	
	void Start () {
		SetUpBoard();
	}
	
	void Update(){
			
	}
	
	string sayName(Transform t){
		return "(" + t.position.x + ", " + t.position.y + ", " + t.position.z + ")";
	}
	
	void SetUpBoard(){
		board = new Transform[width, length];
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < length; y++) {
				Transform newSquare;
				newSquare = (Transform)Instantiate(squarePrefab, new Vector3 (x + xPos, y + yPos, heightPos), Quaternion.identity);
				newSquare.parent = transform;	//puts grid as parent of gameSquare
				newSquare.name = sayName(newSquare);
				newSquare.GetComponent<TerrainTileScript>().base_energy = 10;
				newSquare.GetComponent<TerrainTileScript>().base_regen_rate = 1;
				board[x, y] = newSquare;		//note that this array is x by z so layout (column, row) instead of (row, column)
			}
		}
	}	
	
	public Vector3 snapHeight(Vector3 temp){
		temp.z = heightPos + 1;
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
		if(temp.y < yPos - intersectionOffset){
			temp.y = yPos - intersectionOffset;
		}
		else if(temp.y > yPos + length - 1 + intersectionOffset){
			temp.y = yPos + length - 1 + intersectionOffset;
		}
		float offset = temp.x - xPos - intersectionOffset;
		offset = Mathf.Round(offset);
		temp.x = offset + xPos + intersectionOffset;
		
		offset = temp.y - yPos - intersectionOffset;
		offset = Mathf.Round(offset);
		temp.y = offset + yPos + intersectionOffset;
		
		return temp;
	}
}

