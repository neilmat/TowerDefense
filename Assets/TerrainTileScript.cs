using UnityEngine;
using System.Collections;

public class TerrainTileScript : MonoBehaviour {

	static float global_max_base = 0;
	public float base_energy = 10;
	public float energy_multiplier = 1;
	public float base_regen_rate = 1;
	public float regen_multiplier = 1;
	public float current_energy;
	
	private Renderer renderer;


	// Use this for initialization
	void Start () {
		if (base_energy>global_max_base){
			global_max_base = base_energy;
		}
		current_energy = base_energy*energy_multiplier;
		renderer = this.gameObject.renderer;
	}
	
	// Update is called once per frame
	void Update () {
		current_energy += Time.deltaTime * base_regen_rate * regen_multiplier;
		if (current_energy > base_energy*energy_multiplier){
			current_energy = base_energy*energy_multiplier;
		}
		renderer.material.color = new Color(0,0,current_energy/global_max_base);
	}
}
