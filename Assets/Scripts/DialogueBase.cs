using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (fileName ="New Dialogue" , menuName ="Dialogues") ]
public class DialogueBase : ScriptableObject
{
    [System.Serializable]
    public class Info
    {
        public string myName;
        public Sprite portrait;
       // public Sprite charPortrait;
        [TextArea(4, 3)]
        public string myText;
    }

    [Header("Instert Dialogue Information Below")]
    public Info[] dialogueInfo; 







}
