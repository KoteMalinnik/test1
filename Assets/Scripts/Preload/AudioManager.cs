﻿using UnityEngine;

public class AudioManager : MonoBehaviour
{
	static AudioSource mainThemeSource;

	void Awake()
	{
		DontDestroyOnLoad(this);

		if (gameObject.TryGetComponent(out mainThemeSource)) return;
		mainThemeSource = gameObject.AddComponent<AudioSource>();
	}

	void Start()
	{
		switchSound();
	}

	/// <summary>
	/// Состояние звука. True, если звук вкл., в противном случае false
	/// </summary>
	public static bool audioStatement { get; private set; }

	/// <summary>
	/// Установка значения состояния звука
	/// </summary>
	public static void setAudioStatement(bool newAudioStatement)
	{
		Debug.Log("Музыка: " + newAudioStatement);
		audioStatement = newAudioStatement;

		if (mainThemeSource != null) switchSound();
	}

	/// <summary>
	/// Переключение mainThemeSource
	/// </summary>
	static void switchSound()
	{
		if(audioStatement)
		{
			mainThemeSource.Play();
			return;
		}

		mainThemeSource.Stop();
	}
}