using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitControllers : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("DaughterScene0");
        }
    }
}
