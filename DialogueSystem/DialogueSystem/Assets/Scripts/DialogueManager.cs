﻿using System;
using System.Collections;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = System.Random;

namespace DialogueSystem
{

	public class DialogueManager : Singleton<DialogueManager>
	{
		public event Action<string> ChoiceMade;
		public event Action DialogueEnd;
		[SerializeField] private Button[] buttons;
		[SerializeField] private Image portrait;
		[SerializeField] private Image backgroundView;
		[SerializeField] private Image textBackground;
		[SerializeField] private TextMeshProUGUI actorName;
		[SerializeField] private TextMeshProUGUI dialogueText;
		[SerializeField] private GameObject dialogueObject;
		[SerializeField] private AudioSource letterSoundSource;
		[SerializeField] private AudioSource genericSoundSource;
		private int currentPiece;
		private Coroutine dialogueRoutine;
		private Dialogue currentDialogue;
		public KeyCode confirmButton;
		public KeyCode skipButton;

		protected override void Awake()
		{
			base.Awake();
			if (confirmButton == KeyCode.None || skipButton == KeyCode.None)
			{
				throw new Exception("ERROR: one or more keys were not assigned.\nFrom the inspector assign keys to confirmButton and skipButton");
			}
		}

		public void StartDialogue(Dialogue dialogueToShow)
		{
			currentPiece = 0;
			currentDialogue = dialogueToShow;
			if (dialogueRoutine != null)
			{
				StopDialogue();
			}
			dialogueObject.SetActive(true);
			dialogueRoutine = StartCoroutine(RunningDialoguePiece(currentDialogue.dialoguePieces[currentPiece], dialogueToShow.mode));
		}

		private void StopDialogue()
		{
			if (dialogueRoutine != null)
			{
				StopCoroutine(dialogueRoutine);
			}
			dialogueObject.SetActive(false);
		}

		private void ShowChoices()
		{
			for (int i = 0; i < currentDialogue.choice.Length; i++)
			{
				buttons[i].gameObject.SetActive(true);
				buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = currentDialogue.choice[i].choiceName;
			}
			buttons[0].Select();
		}

		public void PressButton()
		{
			string message = EventSystem.current.currentSelectedGameObject.transform.GetComponentInChildren<TextMeshProUGUI>().text;
			ChoiceMade?.Invoke(message);
			CloseButtons();
			foreach (Choice choice in currentDialogue.choice)
			{
				if (choice.choiceName == message && choice.dialogue != null)
				{
					StartDialogue(choice.dialogue);
					return;
				}
			}

			EndOfDialogueEvent();
			
			StopDialogue();
		}

		private void CloseButtons()
		{
			EventSystem.current.SetSelectedGameObject(null);
			foreach (Button button in buttons)
			{
				button.gameObject.SetActive(false);
			}
		}

		private void EndOfDialogueEvent()
		{
			DialogueEnd?.Invoke();
			DialogueEnd = null;
			ChoiceMade = null;
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
				if (currentDialogue.choice.Length > 0)
				{
					ShowChoices();
				}
				else
				{
					EndOfDialogueEvent();
					StopDialogue();
				}
			}
		}

		private void PlayLetterSound(DialoguePiece piece)
		{
			if (letterSoundSource.isPlaying)
			{
				letterSoundSource.Stop();
			}
			letterSoundSource.clip = piece.letterSound;
			letterSoundSource.pitch = UnityEngine.Random.Range(piece.actor.voicePitchRangeLow, piece.actor.voicePitchRangeHigh);
			letterSoundSource.Play();
		}

		private void PlaySound(DialoguePiece piece)
		{
			genericSoundSource.clip = piece.sound;
			genericSoundSource.Play();
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
				if (c != ' ')
				{
					for (int i = 0; i < piece.speed * currentDialogue.timeForTypeOut; i++)
					{
						if (Input.GetKeyDown(skipButton) || mode == Mode.Instant)
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
					PlayLetterSound(piece);
					yield return null;
				}
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
				if (Input.GetKeyDown(confirmButton) || Input.GetKeyDown(skipButton))
				{
					pressed = true;
					yield return null;
				}
				yield return null;
			}
		}
	}

}