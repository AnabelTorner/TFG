using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 3f;
    public GameObject player;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public CitySpawnManager citySpawnManager;

    float m_Timer;
    bool playerCaught = false;

    //Invisibility bonus
    public BonusManager bonusManager;
    public InvisibilityBonus invisibilityBonusCanvas;

    void Start()
    {
        citySpawnManager = FindObjectOfType<CitySpawnManager>();

        //Invisibility bonus
        bonusManager = FindObjectOfType<BonusManager>();
        invisibilityBonusCanvas = bonusManager.GetComponent<InvisibilityBonus>();
    }

    private void Update()
    {
        if (playerCaught) EndLevel();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !invisibilityBonusCanvas.GetInvisibility())
        {
            playerCaught = true;
        }
    }

    void EndLevel()
    {
        m_Timer += Time.deltaTime;
        caughtBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            citySpawnManager.PlayerCaught();
            citySpawnManager.LoadCityScene();
        }
    }
}
