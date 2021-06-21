using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;
using Color = System.Drawing.Color;

namespace DialogueSystem
{
	[CreateAssetMenu(fileName = "Dialogue", menuName = "Scriptables/Dialogue")]
	public class Dialogue : ScriptableObject
	{
		[TableList] public List<DialoguePiece> dialoguePieces;
		public Choice[] choice;
		public Mode mode = Mode.TypeOut;
		public float timeForTypeOut;
	}
}