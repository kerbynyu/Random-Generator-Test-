using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathmaker2 : MonoBehaviour {

	private int counter = 0;
	public int counterMax = 100;

	public static int globalTileCount = 250;
	public Transform pathmakerSpherePrefab; // you'll have to make a "pathmakerSphere" prefab later
	public Transform objectPrefab; 

	float temp;
	float temp2;

    private void FixedUpdate() {
		
	}

    void Update() {

		

		if (counter < 200) {
			temp = Random.Range(0.0f, 1.0f);
			temp2 = Random.Range(0.0f, 1.0f);

			//Instantiate(pathmakerSpherePrefab, transform.position, transform.rotation);
			if (temp < 0.2f) {
				transform.Rotate(0, 90, 0);

			} else if (0.25f < temp && temp < 0.4f) {
				transform.Rotate(0, -90, 0);

			} else if (0.8f < temp && temp < 1.0f) {
					Instantiate(objectPrefab, transform.position, transform.rotation);
				

			}
			transform.Translate(Vector3.forward * 5);
			Instantiate(objectPrefab, transform.position, transform.rotation);

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


