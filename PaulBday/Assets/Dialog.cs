using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Dialog : MonoBehaviour {

	public Text dialogText;
	public Text giantNumber;
	private int count;
	private int countFruit;
	private AudioSource[] AS;
	private int message = 1;

	// Use this for initialization
	void Start () {
		count = 0;
		countFruit = 0;
		giantNumber.text = "";
		AS = GetComponents<AudioSource>();
		AS[2].Play ();
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Heart"))
		{
			other.gameObject.SetActive (false);
			count++;
			DisplayPointCollected();
			AS[1].Play();
		}
		else if (other.gameObject.CompareTag ("Fruit"))
		{
			other.gameObject.SetActive (false);
			AS[0].Play();
			countFruit++;
		}
	}

	// Update is called once per frame
	void Update () {
		// Press the space key to change the Text message.
		if (Input.GetKeyDown(KeyCode.Return) && message == 1)
		{
			dialogText.text = "You are now at home. You first need to get to Arc de Triomphe";
			message = 2;
		}
		else if (Input.GetKeyDown(KeyCode.Return) && message == 2)
		{
			dialogText.text = "Now your new mission is to collect 10 hearts through Champs-Elyssés";
			message = 3;
		}
		if (count == 10)
		{
			dialogText.text = "Congratulations! You collected 10 hearts... Now Leire will give you a 'besito'.";
			count++;
		}
		if (count == 11 && Input.GetKeyDown(KeyCode.Return))
		{
			dialogText.text = "Your next mission is to go to the Eiffel Tower and get the necessary food to prepare a pique-nique.";
		}
		if (countFruit == 20)
		{
			dialogText.text = "Congratulations! You finished your second task! Now you can have a pique-nique with your love in the Eiffel Tower";
			message = 4;
			countFruit++;
		}		
		if (Input.GetKeyDown(KeyCode.Return) && message == 4)
		{
			dialogText.text = "Happy birthday mon amour! Tu es vraiment le meilleur. J'espère que tu t'as amusé avec le jeux-video. Je t'aime";
		}

	}

	IEnumerator WaitOneSec(){
		yield return new WaitForSeconds(1);
		giantNumber.text = "";

	}

	void DisplayPointCollected()
	{
		giantNumber.text = count.ToString();
		StartCoroutine("WaitOneSec");
	}
}