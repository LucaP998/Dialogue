using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DialogueSystem
{
	public class DialogueStarterTest : MonoBehaviour
	{
		public Dialogue dialogue;

		[Button]
		public void DialogueTest()
		{
			DialogueManager.instance.StartDialogue(dialogue);
			DialogueManager.instance.DialogueEnd += Test;
			DialogueManager.instance.ChoiceMade += Listener;
		}

		private void Test()
		{
			Debug.Log("dialogue is over");
		}
		
		private void Listener(string message)
		{
			if (message == "Yes")
			{
				Debug.Log("yes");
			}
			else if (message == "No")
			{
				Debug.Log("no");
			}
		}
	}
}