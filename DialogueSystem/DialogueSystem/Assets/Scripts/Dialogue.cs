using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Scriptables/Dialogue")]
public class Dialogue : ScriptableObject
{
	public DialoguePiece[] dialoguePieces;

	public enum Mode
	{
		Instant,
		TypeOut
	}

	public Mode mode=Mode.Instant;
	
	public struct Choice
	{
		private string choiceName;
		private Dialogue dialogue;
	}
}
