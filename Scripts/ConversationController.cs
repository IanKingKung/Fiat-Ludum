using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class ConversationController : MonoBehaviour
{
    public string[] dialogueLines;
    public Sprite character1Icon;
    public Sprite character2Icon; 

    public TextMeshProUGUI characterText;
    public TextMeshProUGUI instructionText;
    public Image characterIcon;

    private int dialogueIndex = 0;

    void Start()
    {
        characterText.CrossFadeAlpha(0f, 0f, false);
        characterIcon.CrossFadeAlpha(0f, 0f, false);

        StartCoroutine(DisplayDialogue());
    }

    private IEnumerator DisplayDialogue()
    {
        characterText.transform.parent.gameObject.SetActive(true);
        characterText.gameObject.SetActive(true);
        characterIcon.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        ShowDialogueLine();

        yield return StartCoroutine(WaitForPlayer());
    }

    private IEnumerator WaitForPlayer()
    {
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        dialogueIndex++;

        if (dialogueIndex >= dialogueLines.Length)
        {
            characterText.CrossFadeAlpha(0f, 0f, false);
            characterIcon.CrossFadeAlpha(0f, 0f, false);
            yield return new WaitForSeconds(0.5f);
            characterText.transform.parent.gameObject.SetActive(false);
            characterIcon.gameObject.SetActive(false);
            instructionText.gameObject.SetActive(false);
        }
        else
        {
            characterText.CrossFadeAlpha(0f, 0.5f, false);
            characterIcon.CrossFadeAlpha(0f, 0.5f, false);

            yield return new WaitForSeconds(0.5f);

            ShowDialogueLine();

            yield return StartCoroutine(WaitForPlayer());
        }
    }

    private void ShowDialogueLine()
    {
        characterText.CrossFadeAlpha(1f, 1f, false);
        characterIcon.CrossFadeAlpha(1f, 1f, false);

        characterText.text = dialogueLines[dialogueIndex];

        // Alternate between two characters using modulus
        characterIcon.sprite = (dialogueIndex % 2 == 0) ? character1Icon : character2Icon;
    }
}