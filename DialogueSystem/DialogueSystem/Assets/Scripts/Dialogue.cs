using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;
using Color = System.Drawing.Color;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Scriptables/Dialogue")]
public class Dialogue : ScriptableObject
{
	[Required]
	[SerializeField] private string savePath;
	
	[VerticalGroup("ciao", Order = 0)]
	[Button, GUIColor(0,1,0)]
	private void AddDialoguePiece()
	{
		// var newDialoguePiece = new DialoguePiece();
		// AssetDatabase.CreateAsset(newDialoguePiece, savePath);
		// dialoguePieces.Add(newDialoguePiece);
		// EditorUtility.SetDirty(this);
		// AssetDatabase.SaveAssets();
		Debug.LogError("This button hasn't been implemented yet");
	}
	
	
	[VerticalGroup("casdas", Order = 1)]
	[TableList]
	public List<DialoguePiece> dialoguePieces;

	[VerticalGroup("casdas", Order = 1)]
	public Choice[] choice;

	[VerticalGroup("casdas", Order = 1)]
	public Mode mode=Mode.TypeOut;
	
}