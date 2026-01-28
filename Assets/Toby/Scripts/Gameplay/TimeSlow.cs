using Unity.VisualScripting;
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
            slowFill.fillAmount -= Time.deltaTime / slowCooldown;
        }
        
        else if (slowCooldownTimer <= 0)
        {
            slowFill.color = ready;
            active.SetActive(true);
            if (Input.GetKey(slowKey))
            {
                Time.timeScale = slowAmount;
                float normalTime = Time.deltaTime / Time.timeScale;
                if (normalTime <= 0)
                {
                    normalTime = 1;
                }
                slowDurationTimer -= normalTime;
                if (slowFill.fillAmount <= 0)
                {
                    slowFill.fillAmount = 1;
                }
                slowFill.fillAmount -= Time.deltaTime / slowDuration;
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
            slowCooldownTimer += Time.deltaTime;
            slowFill.fillAmount += Time.deltaTime / slowCooldown;
            if (slowCooldownTimer >= slowCooldown)
            {
                startCooldown = true;
            }
        }
    }
}
