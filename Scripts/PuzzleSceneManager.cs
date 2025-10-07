using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PuzzleSceneManager : MonoBehaviour
{
    public GameObject player;
    public PlayerControllerPuzzleScene playerScript;
    public GameObject ratPrefab;

    void Start()
    {
        playerScript = player.gameObject.GetComponent<PlayerControllerPuzzleScene>();
        StartCoroutine(SpawnRats());
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerScript.isPlayerAlive)
        {
            // Debug.Log("You're dead!");
            SceneManager.LoadScene("PuzzleScene");
            //Or show death screen
        }

        if(player.transform.position.x >= 10)
        {
            SceneManager.LoadScene("DaughterScene");
        }
    }

    private IEnumerator SpawnRats()
    {
        yield return new WaitForSeconds(10f);
        Instantiate(ratPrefab, new Vector2(8f, 0.5f), Quaternion.identity);
        Instantiate(ratPrefab, new Vector2(-3f, 2f), Quaternion.identity);
        Instantiate(ratPrefab, new Vector2(2.5f, -0.2f), Quaternion.identity);
    }
}
