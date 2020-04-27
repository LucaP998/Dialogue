using System;

namespace DialogueSystem
{
	[Serializable]
	public struct Choice
	{
		public string choiceName;
		public Dialogue dialogue;
	}
}