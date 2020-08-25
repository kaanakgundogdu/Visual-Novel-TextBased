using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Dialogue Option", menuName = "Dialogue Options")]
public class DialogueOptions : DialogueBase //Hem dialogue base den elemanları kullanıyor hem de kendi elemanlarını kullanıyor 
{

	[TextArea(2, 10)]
	public string questionText;

	[System.Serializable]
   public class Options
	{

		public string buttonName;
		public DialogueBase nextDialogue;
		public Sprite optionsImage;
		public UnityEvent myEvent;
	}

	public Options[] optionsInfo;

}
