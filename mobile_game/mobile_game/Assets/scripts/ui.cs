using UnityEngine;
using UnityEngine.SceneManagement;

public class ui : MonoBehaviour
{



    void Awake()
    {
        Time.timeScale = 0f; 
    }

    void Update()
    {
        if (Input.touchCount > 0){

            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                StartGame(); 
            }
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false); 
    }
}
