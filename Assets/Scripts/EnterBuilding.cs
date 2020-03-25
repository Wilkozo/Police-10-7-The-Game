using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnterBuilding : MonoBehaviour
{
    // Defined Variables...
    public string TargetScene;
    public Animator transition;
    public string TransitionType;
    public float transitionTime = 1.35f;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // 
            StartCoroutine(Loadlevel(TargetScene));

        }
    }

    IEnumerator Loadlevel(string levelIndex)
    {
        // Play Animation
        //transition.SetTrigger("Start");
        transition.SetTrigger(TransitionType);
        // Wait
        yield return new WaitForSeconds(transitionTime);
        // Load the scene
        // Loads the Target Scene...
        Debug.Log("Enter!");
        //SceneManager.LoadScene(TargetScene);
        Application.LoadLevel(TargetScene);
    }
}
