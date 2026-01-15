using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour
{
    [SerializeField] private List<AudioSource> sourcesOn;
    [SerializeField] private Animator animator;
    [SerializeField] private float transitionTime = 1f;
    public void LoadScene(string scene)
    {
        StartCoroutine(sceneTransition(scene));
    }
    public void LoadSceneWithNoTransition(string scene)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    }
    public void ObjectTransitionIn(Animator animators)
    {
        StartCoroutine(objectTransitionIn(animators));
    }
    public void ObjectTransitionOut(Animator animators)
    {
        StartCoroutine(objectTransitionOn(animators));
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void PlaySound(AudioSource audioSource)
    {
        foreach (AudioSource source in sourcesOn)
        {
            source.Stop();
        }
        audioSource.Play();
    }
    private IEnumerator sceneTransition(string scene)
    {
        animator.SetBool("sceneTransitionIn", true);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(scene);
        Debug.Log("lock in");
    }
    private IEnumerator objectTransitionIn(Animator animators)
    {
        animators.SetBool("sceneTransitionIn", true);
        yield return new WaitForSeconds(transitionTime);
    }

    private IEnumerator objectTransitionOn(Animator animators)
    {
        animators.SetBool("sceneTransitionIn", false);
        yield return new WaitForSeconds(transitionTime);
    }
}