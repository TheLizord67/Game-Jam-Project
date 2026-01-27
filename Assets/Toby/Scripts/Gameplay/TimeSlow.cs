using UnityEditor.Build;
using UnityEngine;
using UnityEngine.UI;

public class TimeSlow : MonoBehaviour
{
    [SerializeField] private float slowAmount;
    
    [SerializeField] private float slowCooldown;
    [SerializeField] private float slowCooldownTimer;
    [SerializeField] private bool startCooldown;

    [SerializeField] private float slowDuration;
    [SerializeField] private float slowDurationTimer;

    [SerializeField] private Slider slowBar;

    [SerializeField] private Image slowFill;
    [SerializeField] public Color cooldownColor;
    [SerializeField] public Color ready;
    [SerializeField] public Color reload;
    [SerializeField] private GameObject active;

    [SerializeField] private KeyCode slowKey;

    [SerializeField] AudioSource slowAudio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slowBar.maxValue = slowCooldown;
        slowCooldownTimer = slowCooldown;
        slowDurationTimer = slowDuration;
    }

    // Update is called once per frame
    void Update()
    {
        slowAudio.pitch = Time.timeScale;
        if (slowCooldownTimer == slowCooldown)
        {
            startCooldown = true;
        }

        if (startCooldown == true && slowCooldownTimer > 0)
        {
            slowFill.color = cooldownColor;
            slowCooldownTimer -= Time.deltaTime;
            slowBar.value = slowCooldownTimer;
        }
        
        else if (slowCooldownTimer <= 0)
        {
            slowFill.color = ready;
            active.SetActive(true);
            slowBar.maxValue = slowDuration;
            if (Input.GetKey(slowKey))
            {
                Time.timeScale = slowAmount;
                float normalTime = Time.deltaTime / Time.timeScale;
                if (normalTime <= 0)
                {
                    normalTime = 1;
                }
                slowDurationTimer -= normalTime;
                slowBar.value = slowDurationTimer;
            }

            if (Input.GetKey(slowKey) == false)
            {
                Time.timeScale = 1f;
            }
            
            if (slowDurationTimer <= 0)
            {
                active.SetActive(false);
                Time.timeScale = 1f;
                slowDurationTimer = slowDuration;
                slowCooldownTimer = 0.01f;
                startCooldown = false;
            }
        }
        
        else if (startCooldown == false)
        {
            slowFill.color = reload;
            slowBar.maxValue = slowCooldown;
            slowCooldownTimer += Time.deltaTime;
            slowBar.value = slowCooldownTimer;
            if (slowCooldownTimer >= slowCooldown)
            {
                startCooldown = true;
            }
        }
    }
}
