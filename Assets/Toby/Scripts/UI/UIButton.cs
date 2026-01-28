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
    public IEnumerator sceneTransition(string scene)
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(transitionTime);
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

    public void Easy()
    {
       Score.difficulty = 1.5f;
    }
    public void Normal()
    {
        Score.difficulty = 1.75f;
    }
    public void Hard()
    {
        Score.difficulty = 2f;
    }
}