using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Player Player;
    public UIManager UIManager;
    public Transform DieZone;

    public int Score;
    private void Awake() 
    {
        Instance = this;
    }
    public void Init() 
    {
        Score = 0;
    }
    public void UpdateScore()
    {
        Score++;
        UIManager.UpdateScoreText(Score);
    }
    private void Update() 
    {
        CheckDie();
    }
    private void CheckDie() 
    {
        if (Player.transform.position.y < DieZone.transform.position.y)
        {
            StartCoroutine(CRDie());
            Debug.Log("DIE");
        }
    }
    private IEnumerator CRDie()
    {
        Player.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }
}
