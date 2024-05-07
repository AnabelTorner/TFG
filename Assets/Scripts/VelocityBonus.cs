using UnityEngine;

public class VelocityBonus : MonoBehaviour
{
    public BonusManager bonusManager;

    public bool velocidadAumento = false;
    public float newMoveSpeed = 3.45f;

    void Start()
    {
        if (bonusManager.GetVelocidadComprada())
        {
            UpdateVelocity();
        }
    }

    void UpdateVelocity()
    {
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        PlayerMovement playerMovement = playerGameObject.GetComponent<PlayerMovement>();
        playerMovement.moveSpeed = newMoveSpeed;
    }

}
