
using UnityEngine;
using UnityEngine.SceneManagement;

public class MirrorController : MonoBehaviour
{
    //holds a place for our UI prompt to "press ... to interact"
    public GameObject promptUI;
    private bool playerInRange = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange && Input.GetKeyDown(KeyCode.Space))
        {
            //place new scene here
            SceneManager.LoadScene("MirrorReflectionScene");
            //Debug.Log("Should load new scene");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(promptUI != null)
            {
                promptUI.gameObject.SetActive(true);
            }
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(promptUI != null)
            {
                promptUI.gameObject.SetActive(false);
            }
            playerInRange = false;
        }
    }
}
