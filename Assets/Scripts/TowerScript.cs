using UnityEngine;
using System.Collections;

public class TowerScript : MonoBehaviour {

	public float sigma2=1;
	public float energy_multiplier = 0.5f;
	public float regen_multiplier = 0.5f;

	// Use this for initialization
	void Start () {
		this.gameObject.transform.position = GameObject.Find("MakeGrid").GetComponent<MakeGrid>().snap(this.gameObject.transform.position);
		ModifyTerrain(energy_multiplier, regen_multiplier);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void ModifyTerrain(float energy_multiplier_base, float regen_multiplier_base){
		GameObject [] terrain_tiles = GameObject.FindGameObjectsWithTag("Terrain");
		//TODO: anything other than gausian
		foreach (GameObject terrain_tile in terrain_tiles) {
			Debug.Log("editing obj");
			float d2 = Mathf.Pow(terrain_tile.transform.position.x-this.gameObject.transform.position.x,2)+
						Mathf.Pow(terrain_tile.transform.position.y-this.gameObject.transform.position.y,2);
			float m = Mathf.Exp(-d2/(2*sigma2));
			Debug.Log("m="+m);
			TerrainTileScript ts = terrain_tile.GetComponent<TerrainTileScript>();
			float em = 1-(1-energy_multiplier_base)*m;
			float rm = 1-(1-regen_multiplier_base)*m;
			ts.energy_multiplier*=em;
			ts.regen_multiplier*=em;
		}
	}
}
