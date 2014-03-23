using UnityEngine;
using System.Collections;

public class TowerScript : MonoBehaviour {

	public float sigma2=1;
	public float energy_multiplier = 0.5f;
	public float regen_multiplier = 0.5f;

	// Use this for initialization
	void Start () {
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
			float d = Vector3.Distance(terrain_tile.transform.position, this.gameObject.transform.position);
			float m = Mathf.Exp(-d*d/(2*sigma2));
			Debug.Log("m="+m);
			TerrainTileScript ts = terrain_tile.GetComponent<TerrainTileScript>();
			float em = 1-(1-energy_multiplier_base)*m;
			float rm = 1-(1-regen_multiplier_base)*m;
			ts.energy_multiplier*=em;
			ts.regen_multiplier*=em;
		}
	}
}
