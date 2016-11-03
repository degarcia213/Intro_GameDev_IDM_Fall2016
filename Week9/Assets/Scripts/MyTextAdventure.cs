using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyTextAdventure : MonoBehaviour {



	public AudioSource sfxSource;
	public Camera mainCam;

	public string currentRoom;
	public string myText;

	private bool hasKey = false;

	//variables to store possible room connections.
	private string room_north;
	private string room_south;
	private string room_west;
	private string room_east;

	// Called the moment that the object is created
	// We use this for intitilization;
	void Start () {
		//change text to read "We ran our scene."
		myText = "We ran our scene.";
	}
	
	// Update is called once per frame
	void Update () {
		//if the player presses space bar, set the text object's
		//text field to say "you pressed spwacebwar."

		/* if (Input.GetKeyDown(KeyCode.Space)) {
			GetComponent<Text>().text = "you pressed spwacebwar.";
		} */


		//we set our rooms to nil, so that if we haven't overwritten them by the time
		//we check for keypresses, we know there's no room.
		room_east = "nil";
		room_north = "nil";
		room_south = "nil";
		room_west = "nil";


		// if I'm in the entryway, I want the game to say "you are in the entryway."
		// else, check the other statements.
		if (currentRoom == "entry"){

			room_north = "hallway";

			myText = "you are in the entryway.\n";
			myText += "The entryway is cool.";


		} else if ( currentRoom == "hallway") {

			room_east = "kitchen";
			room_south = "entry";
			room_west = "locked door";
			
			myText = "you are in the hallway.";

		} else if ( currentRoom == "kitchen") {

			room_west = "hallway";
			
			myText = "You are in the kitchen.";
				if (!hasKey){
				mainCam.backgroundColor = Color.green;
					myText += " You see something sparkling in the drain. Press \"i\" to inspect.";

					if (Input.GetKeyDown(KeyCode.I)){

						currentRoom = "drain";
						

					}
				}

		}  else if (currentRoom == "drain"){

			myText = "You found a key!!! NOICE. Press spacebar to return to the kitchen.";
			if (!hasKey) {
				sfxSource.Play();
			}
			hasKey = true;

			if (Input.GetKeyDown(KeyCode.Space)) {
				currentRoom = "kitchen";
			}

		}else if (currentRoom == "locked door") {

			if (hasKey) {

				myText = "HEYOOOOO YOU GOT TO THE WIN ROOOM!!!! BOIIOIOIOIOING, NICE! Let'S ENJOY CAKE.";

			} else {

				myText = "Sorry, you unlucky person, you need a key.\n\n Press space to return to the hallway";

				if (Input.GetKeyDown(KeyCode.Space)) {
					currentRoom = "hallway";
				}

			}


		} else {

			myText = "You have fallen into a void because the game designer is a garbage game designer and the developer is bad too and some variable is set wrong, specifically currentRoom.";

		}


		// here we're checking for keyboard input
		// if a directional key is pressed
		// we go to the corresponding room.

		myText += "\n\n";
		if (room_north != "nil"){

			myText += "Press Up to go to the " + room_north + "\n";

			if (Input.GetKeyDown(KeyCode.UpArrow)) {
				
				currentRoom = room_north;

			}
		}


		if (room_south != "nil"){

			myText += "Press Down to go to the " + room_south + "\n";

			if (Input.GetKeyDown(KeyCode.DownArrow)){
				
				
				currentRoom = room_south;

			}
		}
	
		if (room_east != "nil"){

			myText += "Press Right to go to the " + room_east + "\n";

			if (Input.GetKeyDown(KeyCode.RightArrow)){
				
				currentRoom = room_east;

			}
		}

		if (room_west != "nil") {

			myText += "Press Left to go to the " + room_west + "\n";

			if (Input.GetKeyDown(KeyCode.LeftArrow)){
				
				currentRoom = room_west;

			}
		}

		//We are acccesing the text component, then using dot notation
		//to modify the text attribute.
		GetComponent<Text>().text = myText;

	}

}
