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

	[Serializable]
	public struct ReactionStruct
	{
		public Reaction reaction;
		[PreviewField(ObjectFieldAlignment.Center)]
		public Sprite sprite;
	}
	
	public List<ReactionStruct> reactions = new List<ReactionStruct>();

	public Sprite GetSprite(Reaction reaction)
	{
		ReactionStruct result = reactions.Find(x => x.reaction == reaction);
		return result.sprite;
	}

}