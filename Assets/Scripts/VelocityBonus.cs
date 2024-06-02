using UnityEngine;
using UnityEngine.SceneManagement;

public class VelocityBonus : MonoBehaviour
{
    public BonusManager bonusManager;

    public float newMoveSpeed = 3.45f;
    public float initialMoveSpeed = 3f;

    void Start()
    {
        if (bonusManager.GetVelocidadComprada())
        {
            UpdateVelocity();
        }
    }

    public void UpdateVelocity()
    {
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        PlayerMovement playerMovement = playerGameObject.GetComponent<PlayerMovement>();
        playerMovement.moveSpeed = newMoveSpeed;
    }

    public void restartVelocity()
    {
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        PlayerMovement playerMovement = playerGameObject.GetComponent<PlayerMovement>();
        playerMovement.moveSpeed = initialMoveSpeed;
    }

}
