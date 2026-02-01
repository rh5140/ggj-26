using UnityEngine;
using TMPro;
using System;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public bool startOnAwake = true;
    public float currentTime = 0f;
    public bool isRunning = false;
    
    // Event triggered when timer stops
    public event Action<float> OnTimerStop;
    
    void Start()
    {
        // Initialize time to 0
        currentTime = 0f;
        
        if (startOnAwake)
        {
            StartTimer();
        }
        
        UpdateTimerDisplay();
    }
    
    void Update()
    {
        if (isRunning)
        {
            // Count up from 0
            currentTime += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }
    
    void UpdateTimerDisplay()
    {
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timerText.text = time.ToString(@"mm\:ss");
    }
    
    // Start the timer
    public void StartTimer()
    {
        isRunning = true;
    }
    
    // Pause the timer
    public void PauseTimer()
    {
        isRunning = false;
    }
    
    // Stop timer and trigger event with final time
    public void StopTimer()
    {
        isRunning = false;
        OnTimerStop?.Invoke(currentTime);
    }
    
    // Reset timer to 0
    public void ResetTimer()
    {
        currentTime = 0f;
        UpdateTimerDisplay();
    }
    
    // Get current time in seconds
    public float GetCurrentTime()
    {
        return currentTime;
    }
    
    // Get formatted time string (mm:ss)
    public string GetFormattedTime()
    {
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        return time.ToString(@"mm\:ss");
    }
    
}