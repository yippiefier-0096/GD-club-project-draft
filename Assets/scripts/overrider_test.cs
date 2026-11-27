using Unity.VisualScripting;
using UnityEngine;

public class overrider_test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (gameManager.player_main.IsUnityNull())
        {
            gameManager.player_main=this.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
