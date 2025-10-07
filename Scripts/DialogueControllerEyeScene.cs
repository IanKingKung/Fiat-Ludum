using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueControllerEyeScene : MonoBehaviour
{
    public TextMeshProUGUI characterText;
    public TextMeshProUGUI instructionText;
    public Image characterIcon;
    public string[] dialogue;
    private int dialogueIndex = 0;
    void Start()
    {
        characterText.CrossFadeAlpha(0f, 0f, false);
        characterIcon.CrossFadeAlpha(0f, 0f, false);

        StartCoroutine(DisplayDialogue());
    }


    //will display dialogue after 1 second
    private IEnumerator DisplayDialogue()
    {
        characterText.transform.parent.gameObject.SetActive(true);
        characterText.gameObject.SetActive(true);
        characterIcon.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        characterText.CrossFadeAlpha(0.5f, 0.5f, false);
        characterIcon.CrossFadeAlpha(0.5f, 0.5f, false);
        characterText.text = dialogue[dialogueIndex];

        yield return StartCoroutine(WaitForPlayer());
    }


    //wait for player to press space and then continue with dialogue
    private IEnumerator WaitForPlayer()
    {
        while(!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;      //return null
        }

        dialogueIndex++;

        if(dialogueIndex >= dialogue.Length)
        {
            //if we're done with dialogue remove the words icon, and panel
            characterText.CrossFadeAlpha(0f, 0f, false);
            characterIcon.CrossFadeAlpha(0f, 0f, false);
            yield return new WaitForSeconds(0.5f);
            characterText.transform.parent.gameObject.SetActive(false);
            characterIcon.gameObject.SetActive(false);
            instructionText.gameObject.SetActive(false);
            SceneManager.LoadScene("BossScene");
        }
        else
        {
            characterText.CrossFadeAlpha(0f, 0.5f, false);
            characterIcon.CrossFadeAlpha(0f, 0.5f, false);

            yield return new WaitForSeconds(0.5f);

            characterText.CrossFadeAlpha(1f, 1f, false);
            characterIcon.CrossFadeAlpha(1f, 1f, false);
            characterText.text = dialogue[dialogueIndex];

            yield return StartCoroutine(WaitForPlayer());
        }
    }


}
