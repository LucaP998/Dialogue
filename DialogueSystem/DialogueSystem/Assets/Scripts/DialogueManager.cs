using System;
using System.Collections;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager>
{
	public bool isRunning;
	private event Action<string> ChoiceMade;
	[SerializeField] private Image portrait;
	[SerializeField] private Image backgroundView;
	[SerializeField] private Image textBackground;
	[SerializeField] private TextMeshProUGUI actorName;
	[SerializeField] private TextMeshProUGUI dialogueText;
	[SerializeField] private Canvas canvas;
	[SerializeField] private AudioSource letterSource;
	[SerializeField] private AudioSource genericSound;
	private int currentPiece;
	private Coroutine dialogueRoutine;
	public Dialogue currentDialogue;
	

	
	[Button]
	public void StartDialogue(Dialogue dialogueToShow)
	{
		currentDialogue = dialogueToShow;
		if (dialogueRoutine != null)
		{
			StopDialogue();
		}
		canvas.enabled = true;
		dialogueRoutine = StartCoroutine(RunningDialoguePiece(currentDialogue.dialoguePieces[currentPiece], dialogueToShow.mode));
	}

	private void StopDialogue()
	{
		if (dialogueRoutine != null)
		{
			StopCoroutine(dialogueRoutine);
		}
		canvas.enabled = false;
	}

	private void ShowButton()
	{ }

	private void PressButton()
	{
		//Debug.Log(EventSystem.current.currentSelectedGameObject.transform.GetComponentInChildren<TextMeshProUGUI>().text);
	}

	private void NextDialoguePiece()
	{
		currentPiece++;
		if (currentPiece < currentDialogue.dialoguePieces.Count)
		{
			StartCoroutine(RunningDialoguePiece(currentDialogue.dialoguePieces[currentPiece], currentDialogue.mode));
		}
		else
		{
			StopDialogue();
		}
	}
	
	private void PlayLetterSound(DialoguePiece piece)
	{
		letterSource.clip = piece.letterSound;
		letterSource.Play();
	}

	private void PlaySound(DialoguePiece piece)
	{
		genericSound.clip = piece.sound;
		genericSound.Play();
	}

	IEnumerator RunningDialoguePiece(DialoguePiece piece, Mode mode)
	{
		bool isSkip = false;
		actorName.text = piece.actor.name;
		portrait.sprite = piece.spriteReaction;
		dialogueText.text = "";
		PlaySound(piece);
		foreach (char c in piece.dialogueText)
		{
			dialogueText.text += c;
			PlayLetterSound(piece);
			for (int i = 0; i < piece.speed * 60; i++)
			{
				if (Input.anyKeyDown)
				{
					dialogueText.text = piece.dialogueText;
					isSkip = true;
					break;
				}
				yield return null;
			}
			if (isSkip)
			{
				break;
			}
			yield return null;
		}
		yield return null;
		yield return StartCoroutine(WaitForInput());
		NextDialoguePiece();
	}

	IEnumerator WaitForInput()
	{
		bool pressed = false;
		while (!pressed)
		{
			if (Input.anyKeyDown)
			{
				pressed = true;
				yield return null;
			}
			yield return null;
		}
	}
}