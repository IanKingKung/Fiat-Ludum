using UnityEngine;
using UnityEngine.SceneManagement;

public class BossSceneManager : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x > 10)
        {
            SceneManager.LoadScene("ReflectionScene");
        }
    }
}
