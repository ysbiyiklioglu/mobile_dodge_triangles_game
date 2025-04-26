using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movemment : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    bool aktive = false;
    [SerializeField] private GameObject panel; 
    [SerializeField] private time_ui timer;  // Inspector’da bağlayın
    private void OnCollisionEnter2D(Collision2D collision)
    {
    
    panel.SetActive(true);
    aktive = true;
    Time.timeScale = 0f; 
    }
    
    private void Start()
    {
       
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float horizontalMovement = touch.deltaPosition.x * speed * Time.deltaTime;
                transform.Translate(horizontalMovement, 0f, 0f);

                
                Vector3 clampedPos = transform.position;
                clampedPos.x = Mathf.Clamp(clampedPos.x, -2f, 2f);
                transform.position = clampedPos;
            }
            if (aktive == true)
            {
                if (touch.phase == TouchPhase.Began)
                {
                            // Bitmeden önce en iyiyi kaydet
                     timer.SaveHighScore();
                    
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Mevcut sahneyi yeniden yükle
                }
            }
        }
    }

}