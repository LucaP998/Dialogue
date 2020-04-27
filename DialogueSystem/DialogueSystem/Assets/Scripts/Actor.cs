using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Actor", menuName = "Scriptables/Actor")]
[Serializable]
public class Actor : ScriptableObject
{
	public string actorName;
	public float voicePitchRangeHigh = 1;
	public float voicePitchRangeLow = 1;
	[HideInInspector] public int index;

	[Serializable]
	public class ReactionStruct
	{
		public Reaction reaction;
		[PreviewField(ObjectFieldAlignment.Center)]
		public Sprite sprite;
	}
	
	
	[OnValueChanged("NewReaction")]
	public List<ReactionStruct> reactions = new List<ReactionStruct>();

	
	
	private void NewReaction()
	{
		if (reactions.Count > 0)
		{
			reactions[reactions.Count - 1].reaction = (Reaction)Enum.ToObject(typeof(Reaction), index);
			index++;
			if (index >= Enum.GetNames(typeof(Reaction)).Length)
			{
				index = 0;
			}
		}
	}
	
	public Sprite GetSprite(Reaction reaction)
	{
		ReactionStruct result = reactions.Find(x => x.reaction == reaction);
		return result.sprite;
	}

}