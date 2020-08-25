using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
	public static DialogueManager myInstance;
	public void Awake()
	{
		if(myInstance!=null)
		{
			Debug.LogWarning("Fix This" + gameObject.name);
		}
		else
		{
			myInstance = this;
		}
	}

	//options
	private bool isDialogueOption;
	[SerializeField]
	private GameObject dialogueOptionsUI;
	[SerializeField]
	private GameObject[] optionButtons;
	private int optionsAmaount;
	[SerializeField]
	private Text questionText;
	[SerializeField]
	private Image newoptionsImage;


	//dialogue
	[SerializeField]
	private GameObject dialogueBox;
	[SerializeField]
	private GameObject namePanel;
	public Text dialogueName;
	[SerializeField]
	private Text dialogueText;
	[SerializeField]
	private Image dialoguePortrait;
	//public Image charImage;
	private bool inDialogue;

	private Queue<DialogueBase.Info> dialogueInfo = new Queue<DialogueBase.Info>();  //FIFO collection , first in first out
	//enqueue ile girişler alınır
	//dequeue ile çıkışlar giriş sırasına göre sağlanır


	public void EnqueueDialogue (DialogueBase db)
	{
		if (inDialogue)
		{
			return;
		}
		inDialogue = true;
		dialogueBox.SetActive(true);
		dialogueInfo.Clear(); // clear any prewious info 

		//Dialogue Settings
		DialogueSettings(db);
		
		foreach (DialogueBase.Info info in db.dialogueInfo)
		{
			dialogueInfo.Enqueue(info);
		}

		DequeueDialogue();
	}

	public void DequeueDialogue()
	{

		if (dialogueInfo.Count==0)
		{
			EndDialogue();
			return;
		}
		//add in code that detects if we have no more dialogue and return
		DialogueBase.Info info = dialogueInfo.Dequeue();

		dialogueName.text = info.myName;

		//Boşken paneli kapatıyoruz.
		if (dialogueName.text == "")
		{
			RemoveName(info);
		}
		else
		{
			namePanel.SetActive(true);
		}

		dialogueText.text = info.myText;
		dialoguePortrait.sprite = info.portrait;
		//charImage.sprite = info.charPortrait; //Karakterin resmini başka panele koyacaktım sonra kafam karıştı koymadım xd

		StartCoroutine(TypeText(info));
	}

	private void DialogueSettings(DialogueBase db)
	{
		if (db is DialogueOptions)
		{
			isDialogueOption = true;

			DialogueOptions dialogueOptions = db as DialogueOptions;
			optionsAmaount = dialogueOptions.optionsInfo.Length;
			questionText.text = dialogueOptions.questionText;

			for (int i = 0; i < optionButtons.Length; i++)
			{
				optionButtons[i].SetActive(false);
			}
			//options events
			OptionsEvents(db);
		}

		else
		{
			isDialogueOption = false;
		}
	}

	private void OptionsEvents(DialogueBase db)
	{
		DialogueOptions dialogueOptions = db as DialogueOptions;
		for (int i = 0; i < optionsAmaount; i++)
		{
			optionButtons[i].SetActive(true);
			optionButtons[i].transform.GetChild(0).gameObject.GetComponent<Text>().text = dialogueOptions.optionsInfo[i].buttonName;
			UnityEventHandler myEventHandler = optionButtons[i].GetComponent<UnityEventHandler>();
			myEventHandler.eventHandler = dialogueOptions.optionsInfo[i].myEvent;
			if (dialogueOptions.optionsInfo[i].nextDialogue != null)
			{
				myEventHandler.myDialogueBase = dialogueOptions.optionsInfo[i].nextDialogue;
			}
			else
			{
				myEventHandler.myDialogueBase = null;
			}

			if (dialogueOptions.optionsInfo[i].optionsImage != null)
			{
				newoptionsImage.sprite = dialogueOptions.optionsInfo[i].optionsImage;
			}
			else
			{
				newoptionsImage.sprite = null;
			}
		}
	}


	IEnumerator TypeText(DialogueBase.Info newInfo)
	{
		WaitForSeconds delay = new WaitForSeconds(0.001f);
		dialogueText.text = "";
		foreach  (char c in newInfo.myText.ToCharArray())
		{
			yield return delay;
			dialogueText.text += c;
			yield return null;
		}


	}

	public void EndDialogue()
	{
		dialogueBox.SetActive( false);
		inDialogue = false;
		OptionLogic();

	}

	private void OptionLogic()
	{
		if (isDialogueOption)
		{
			dialogueOptionsUI.SetActive(true);
		}
	}


	public void CloseOptions()
	{
		dialogueOptionsUI.SetActive(false);
	}

	public void RemoveName(DialogueBase.Info info )
	{
		namePanel.SetActive(false);
	}

}
