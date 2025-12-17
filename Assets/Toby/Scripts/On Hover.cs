using UnityEngine;
using UnityEngine.UI;
using System.Collections; 
using System.Collections.Generic; 
using UnityEngine.Events;

public class OnHover : MonoBehaviour
{
    public Animator animator;
    public string animatorTrigger;
    public AudioSource audioSource;
    public Image preview;
    public UnityEvent hoverEvent;
    public UnityEvent hoverOffEvent;

    public void AnimationPlayBool()
    {
        animator.SetBool(animatorTrigger, true);
    }
    
    public void AnimationStopBool()
    {
        animator.SetBool(animatorTrigger, false);
    }

    public void AudioPlay()
    {
        audioSource.Play();
    }
    
    public void AudioStop()
    {
        audioSource.Stop();
    }

    public void ShowPreview()
    {
        preview.enabled = true;
    } 

    public void HidePreview()
    {
        preview.enabled = false;
    }

    public void HoverEventInvoke()
    {
        hoverEvent.Invoke();
    } 

    public void HoverOffEventInvoke() 
    { 
        hoverOffEvent.Invoke(); 
    }
}
