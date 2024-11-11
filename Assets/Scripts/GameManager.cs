using UnityEngine;

public class GameManager : MonoBehaviour
{


    private void Update()
    {
        if (GameInput.GetKeyDown(KeyType.Q))
        {
            Debug.Log("Press Down Q");
        }
        if (GameInput.GetKey(KeyType.Q))
        {
            Debug.Log("Pressing Q");
        }
        if (GameInput.GetKeyUp(KeyType.Q))
        {
            Debug.Log("Press Up Q");
        }
    }
}
