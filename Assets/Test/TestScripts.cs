using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScripts : MonoBehaviour
{
	[SerializeField]
	private DialogueBase dialogue;
	[SerializeField]
	private GameObject startButton;

	public void TriggerDialogue()
	{
		DialogueManager.myInstance.EnqueueDialogue(dialogue);
	}
	public void StartWhenClicked()
	{
		if (startButton != null)
		{
			TriggerDialogue();
			startButton.SetActive(false);
		}
		else
		{
			Debug.LogError("Add Button to this game obj" + startButton);
		}

	}

}
