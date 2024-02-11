using System;
using UnityEngine;
using System.Text;
using TMPro;

public class DebugPanel : MonoBehaviour
{
    public GameObject DebugPanelWindow;
    public TextMeshProUGUI debugText;
    public float messageDuration = 15f;
    public int maxMessages = 10; // Лимит сообщений

    private float currentMessageTime = 0f;
    private bool isDebugPanelVisible = false;
    private StringBuilder logMessages = new StringBuilder();

    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    private void Start()
    {
        HideDebugPanel();
    }

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.F12))
		{
			isDebugPanelVisible = !isDebugPanelVisible;
			if (isDebugPanelVisible)
			{
				ShowDebugPanel();
			}
			else
			{
				HideDebugPanel();
			}
		}
		
		// Обновление текстовой панели в реальном времени
		if (isDebugPanelVisible)
		{
			currentMessageTime += Time.deltaTime;

			if (currentMessageTime >= messageDuration)
			{
				HideDebugPanel();
			}

			UpdateDebugText(logMessages.ToString());
		}
	}

	private void HandleLog(string logMessage, string stackTrace, LogType type)
	{
		// Разделите строку stackTrace на строки, используя символ новой строки в качестве разделителя
		string[] traceLines = stackTrace.Split('\n');

		// Получите код, вызвавший дебаг-сообщение, из третьей строки stackTrace
		if (traceLines.Length > 2)
		{
			string codeLine = traceLines[2].Trim();
			logMessage += "\n" + codeLine;
		}

		// Регистрировать все типы сообщений (LogType.Warning, LogType.Error и т. д.)
		logMessages.AppendLine(logMessage);

		// Вызвать метод для добавления дебаг-сообщения
		AddDebugMessage(logMessage);

		// Активировать дебаг-панель при получении нового сообщения
		ShowDebugPanel();
	}

	public void AddDebugMessage(string message)
	{
		logMessages.AppendLine(message);
		// Очистить старые сообщения при достижении максимального размера
		while (logMessages.Length > maxMessages)
		{
			int newLineIndex = logMessages.ToString().IndexOf('\n');
			if (newLineIndex >= 0)
			{
				logMessages.Remove(0, newLineIndex + 1);
			}
			else
			{
				break;
			}
		}

		UpdateDebugText(logMessages.ToString());
	}
	
	private void UpdateDebugText(string message)
    {
        debugText.text = message;
    }

    private void ShowDebugPanel()
    {
        DebugPanelWindow.SetActive(true);
    }

    private void HideDebugPanel()
    {
        DebugPanelWindow.SetActive(false);
    }
}