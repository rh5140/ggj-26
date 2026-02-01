using UnityEngine;
using TMPro;
using System;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public bool startOnAwake = true;
    public float startMinutes = 5f;  // Start time (in minutes)
    public float currentTime = 0f;
    public bool isRunning = false;
    
    // Event triggered when countdown ends
    public event Action OnTimerEnd;
    
    void Start()
    {
        // Initialize time to 5 minutes (converted to seconds)
        currentTime = startMinutes * 60f + 1f; // Add 1 second to ensure correct display
        
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
            // Countdown
            currentTime -= Time.deltaTime;
            
            // If time reaches 0
            if (currentTime <= 0f)
            {
                currentTime = 0f;
                isRunning = false;
                
                // Trigger end event
                OnTimerEnd?.Invoke();
            }
            
            UpdateTimerDisplay();
        }
    }
    
    void UpdateTimerDisplay()
    {
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timerText.text = time.ToString(@"mm\:ss");
    }
    
    // Other public methods to control the timer
    public void StartTimer()
    {
        isRunning = true;
    }
    
    public void PauseTimer()
    {
        isRunning = false;
    }
    
    public void ResetTimer()
    {
        currentTime = startMinutes * 60f;
        UpdateTimerDisplay();
    }
    
    public float GetCurrentTime()
    {
        return currentTime;
    }
}