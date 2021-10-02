using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField]
    private TMP_Text coinsText;

    [Header("ScriptableObjects")]
    [SerializeField]
    private Data data;
    [SerializeField]
    private ObstacleHittedChannel obstacleHittedChannel;
    [SerializeField]
    private KnifeHandleCollision knifeCableCollision;
    [SerializeField]
    private WinCollisionChannel winCollisionChannel;

    [Header("Others")]
    [SerializeField]
    private GameObject restartPopUp;    
    [SerializeField]
    private GameObject winPopUp;

    private void Awake()
    {
        ValueUpdate();
    }

    private void OnEnable()
    {
        obstacleHittedChannel.OnObstacleHitted += ValueUpdate;
        knifeCableCollision.OnCableTrigger += RestartPopUp;
        winCollisionChannel.OnWinCollision += WinPopUp;
    }
    private void OnDisable()
    {
        obstacleHittedChannel.OnObstacleHitted -= ValueUpdate;
        knifeCableCollision.OnCableTrigger -= RestartPopUp;
        winCollisionChannel.OnWinCollision -= WinPopUp;
    }

    public void ValueUpdate()
    {
        coinsText.text = "$ " + data.Coins.ToString();
    }

    private void RestartPopUp()
    {
        restartPopUp.SetActive(true);
        Time.timeScale = 0;
    }

    private void WinPopUp()
    {
        winPopUp.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
