using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Scriptables/Dialogue")]
public class Dialogue : ScriptableObject
{
	[TableList]
	public List<DialoguePiece> dialoguePieces;
	public Choice[] choice;

	public Mode mode=Mode.TypeOut;
	
}
