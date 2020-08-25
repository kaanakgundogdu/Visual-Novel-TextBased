using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UnityEventHandler : MonoBehaviour, IPointerDownHandler
{
	public UnityEvent eventHandler;
	public DialogueBase myDialogueBase;

	//Clicked
	public void OnPointerDown(PointerEventData pointerEventData)
	{
		eventHandler.Invoke();
		DialogueManager.myInstance.CloseOptions();

		if (myDialogueBase!=null)
		{
			DialogueManager.myInstance.EnqueueDialogue(myDialogueBase);
		}

	}
}
