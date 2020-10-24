using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pathmaker : MonoBehaviour {

	private int counter = 0; 
	public int counterMax = 100;

	public Transform floorPrefab; 
	public static int globalTileCount = 250; 
	public Transform pathmakerSpherePrefab; // you'll have to make a "pathmakerSphere" prefab later
	public Transform roadPrefab;
	public Transform grassPrefab;
	public Transform treePrefab; 
	public Transform build1PFB;
	public Transform build2PFB;
	public Transform build3PFB;

	float temp;
	float temp2; 

	void Update () {
        if (counter < 200){
			temp = Random.Range(0.0f, 1.0f);
			temp2 = Random.Range(0.0f, 1.0f);

			//Instantiate(pathmakerSpherePrefab, transform.position, transform.rotation);
			if (temp < 0.2f) {
				transform.Rotate(0, 90, 0);

			} else if (0.25f< temp && temp < 0.4f){
				transform.Rotate(0, -90, 0);

			} else if (0.8f < temp && temp < 1.0f) {
                if (temp2 < 0.15) {
					Vector3 treePos = new Vector3(transform.position.x, transform.position.y, 0);
					Instantiate(treePrefab, treePos, transform.rotation);

				} else if(0.15 < temp2 && temp2< 0.3){
					Vector3 build1Pos = new Vector3(transform.position.x, transform.position.y + 7, transform.position.z);
					Instantiate(build1PFB, build1Pos, transform.rotation);

				} else if (0.3 < temp2 && temp2 < 0.45) {
					Vector3 build2Pos = new Vector3(transform.position.x, transform.position.y + 7, transform.position.z);
					Instantiate(build2PFB, build2Pos, transform.rotation);

				} else if (0.45 < temp2 && temp2 < 0.6) {
					Vector3 build3Pos = new Vector3(transform.position.x, transform.position.y + 7, transform.position.z);
					Instantiate(build3PFB, build3Pos, transform.rotation);

				} else {
					Instantiate(grassPrefab, transform.position, transform.rotation);
				}

			}
			transform.Translate(Vector3.forward*5);
			Instantiate(grassPrefab, transform.position, transform.rotation);

			counter++;

        } else {
			Destroy(this);
		}

		if (counter > globalTileCount) {
			Destroy(this);

		}
	}
} 

// STEP 5: ===================================================================================
// maybe randomize it even more?

// - randomize 2 more variables in Pathmaker.cs for each different Pathmaker... you would do this in Start()
// - maybe randomize each pathmaker's lifetime? maybe randomize the probability it will turn right? etc. if there's any number in your code, you can randomize it if you move it into a variable



// STEP 6:  =====================================================================================
// art pass, usability pass



//		- then, add a simple in-game restart button; let us press [R] to reload the scene and see a new level generation
// - with Text UI, name your proc generation system ("AwesomeGen", "RobertGen", etc.) and display Text UI that tells us we can press [R]


// OPTIONAL EXTRA TASKS TO DO, IF YOU WANT / DARE: ===================================================

// AVOID SPAWNING A TILE IN THE SAME PLACE AS ANOTHER TILE  https://docs.unity3d.com/ScriptReference/Physics.OverlapSphere.html
// Check out the Physics.OverlapSphere functionality... 
//     If the collider is overlapping any others (the tile prefab has one), prevent a new tile from spawning and move forward one space. 

// DYNAMIC CAMERA:
// position the camera to center itself based on your generated world...
// 1. keep a list of all your spawned tiles
// 2. then calculate the average position of all of them (use a for() loop to go through the whole list) 
// 3. then move your camera to that averaged center and make sure fieldOfView is wide enough?

// WALL GENERATION
// add a "wall pass" to your proc gen after it generates all the floors
// 1. raycast downwards around each floor tile (that'd be 8 raycasts per floor tile, in a square "ring" around each tile?)
// 2. if the raycast "fails" that means there's empty void there, so then instantiate a Wall tile prefab
// 3. ... repeat until walls surround your entire floorplan
// (technically, you will end up raycasting the same spot over and over... but the "proper" way to do this would involve keeping more lists and arrays to track all this data)
