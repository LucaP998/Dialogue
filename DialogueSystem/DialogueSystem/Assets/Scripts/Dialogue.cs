using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Scriptables/Dialogue")]
public class Dialogue : ScriptableObject
{
	[TableList]
	public List<DialoguePiece> dialoguePieces;


	public Mode mode=Mode.Instant;
	
	[Serializable]
	public struct Choice
	{
		private string choiceName;
		private Dialogue dialogue;
	}
}
