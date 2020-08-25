using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "Events")]
public class EventBehaviour : ScriptableObject
{
	//Tek bir butonla multiple events de yapabilirsin
	//Burası butonlara basıldığında bir event yapılacaksa diye var sonra kullanırım xd
	public void Testevent()
	{
		Debug.LogError("test1");
	}

	public void Testevent2()
	{
		Debug.LogError("test2");
	}

	public void Testevent3()
	{
		Debug.LogError("test3");
	}
}
