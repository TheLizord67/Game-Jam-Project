using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator animator; 
    public void OnEnable()
    {
        StartCoroutine(TransitionIn());
    }


    private IEnumerator TransitionIn()
    {
        animator.SetBool("idle", false);
        animator.SetBool("sceneTransitionOut", true);
        yield return new WaitForSeconds(3.1f);
        animator.SetBool("sceneTransitionOut", false);
        animator.SetBool("idle", true);
    }

}
