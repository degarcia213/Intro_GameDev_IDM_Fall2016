using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextAdventure : MonoBehaviour {

	// -- Remember that you need to assign your script to your text object in your scene before it will do anything!!

	//this is a string that will keep track of the room we're in.
	public string currentRoom;

	public AudioSource sfxSource;
	public Camera myCam;

	// these will help us change rooms efficiently.
	private string room_up;
	private string room_down;
	private string room_left;
	private string room_right;

	public string textBuffer;

	// here we set up a boolean to track if we've picked up a key, and we're also going to default it to false.
	private bool hasKey = false;

	// Start runs the moment the object with this script is created -- so in our case, when the project is run. Use it to "initialize" values.
	void Start () {
		// GetComponent<Text>().text = "Hey, we ran the project.";
		// the above line would set our text immediately to a default value, but we actually don't need this, so I have commented it out with "//"

		// here I have "initialized" our currentRoom variable.
		currentRoom = "entryway";

		// I'm also initializing our room variables to nil.
		room_down = "nil";
		room_up = "nil";
		room_left = "nil";
		room_right = "nil";

	}
	
	// Update is called once per frame
	void Update () {

		// here we reset our room variables to "nil" so that we don't accidentally create unwanted connections. 
		// Since code is read top to bottom, this'll be overwritten by the if statement below.
		room_down = "nil";
		room_up = "nil";
		room_left = "nil";
		room_right = "nil";

		myCam.backgroundColor = Color.black;


		//here we define our text for our rooms, and also overwrite any necessary direction variables so we have the proper connections.
		if (currentRoom == "entryway") {
			//overwriting the room_up variable because we want a hallway above our entrway.
			room_up = "hallway";

			// setting our descriptive text. You can use += to concatenate strings. COOL. "\n" adds a line break.
			textBuffer = "You are standing in the entryway.\n";
			textBuffer += "Cool entryway.";

		} else if (currentRoom == "hallway") {
			room_down = "entryway";
			room_left = "door marked win";
			room_right = "library";

			textBuffer = "You are now in the hallway.";
		} else if (currentRoom == "door marked win") {

			// here we check the "hasKey" variable. If it's still false, we show the player a locked door. Otherwise, they win.
			if (hasKey) {
				textBuffer = "You unlocked the door and are standing in front of a cake. You win!";
			} else {
				room_right = "hallway";

				textBuffer = "This door is locked. A note taped to the door reads, \"haha, idiot.\"";
			}
		} else if (currentRoom == "library") {
			room_left = "hallway";

			if (!hasKey) {
				sfxSource.Play();
			}
			textBuffer = "You are in the library. You look in a book and there's a key! You take the key.";

			// we set the hasKey variable to true. Now the player can win.
			hasKey = true;
		}

		//just adding some padding before the next section
		textBuffer += "\n\n";

		// Here we check if we've set our room variables to something other than "nil," 
		// and if so, we let the player know they can press the corresponding button to go there.
		// We'll also put our keypresses in here, so that we only change rooms if a room exists.
		if (room_up != "nil")
		{
			textBuffer += "Press Up to go to the " + room_up + "\n";


			// here is our button controls for changing rooms!! 
			// We pass a key into the "Input.GetKeyDown" function to detect the moment that key is pressed down, 
			// then set our currentRoom variable to be equal to the corresponding room direction variable.
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				currentRoom = room_up;
			}
		}
		if (room_down != "nil")
		{
			textBuffer += "Press Down to go to the " + room_down + "\n";

			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				currentRoom = room_down;
			}
		}
		if (room_left != "nil")
		{
			textBuffer += "Press Left to go to the " + room_left + "\n";

			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				currentRoom = room_left;
			}
		}
		if (room_right != "nil")
		{
			textBuffer += "Press Right to go to the " + room_right + "\n";

			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				currentRoom = room_right;
			}
		}


		// finally, we assign the text we've constructed in the text buffer to our text component
		// of the object to which this script is assigned, so that it will display on screen.
		GetComponent<Text>().text = textBuffer;
	}
}
