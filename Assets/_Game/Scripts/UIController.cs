using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

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
    private KnifeCableCollision knifeCableCollision;

    [Header("Others")]
    [SerializeField]
    private UnityEvent _events;

    private void Awake()
    {
        ValueUpdate();
    }

    private void OnEnable()
    {
        obstacleHittedChannel.OnObstacleHitted += ValueUpdate;
        knifeCableCollision.OnCableTrigger += RestartPopUp;
    }
    private void OnDisable()
    {
        obstacleHittedChannel.OnObstacleHitted -= ValueUpdate;
        knifeCableCollision.OnCableTrigger -= RestartPopUp;
    }

    public void ValueUpdate()
    {
        coinsText.text = "$ " + data.Coins.ToString();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void RestartPopUp()
    {
        _events.Invoke();
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
