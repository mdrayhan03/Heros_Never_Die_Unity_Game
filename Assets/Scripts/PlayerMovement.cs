using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body ;
    private Animator anim ;
    [SerializeField] private float speed ;
    private int life = 3 ;
    private int shoot = 3 ;
    private int score = 0 ;
    private bool gameRun = true ;
    [SerializeField] public TextMeshProUGUI lifeText ;
    [SerializeField] public TextMeshProUGUI shootText ;
    [SerializeField] public TextMeshProUGUI scoreText ;
    [SerializeField] public TextMeshProUGUI martyrText ;
    List<string> martyr = new List<string> {"A K M Shahidul Islam", "Abdul Al Mahin", "Abdul Awal Miya", "JINNATUL ISLAM KHOKON", "JAhirul Islam", "IFFAT HOSSAIN", "Humaiyan Kabir", "Hridoy Hossen Shihab", "SUHAG MIA", "SORUJ ALI BABU", "Sobuz", "Sobhan Munsi", "Mugdho", "Sobhan Munsi", "Sohel Rana", "OMOR FARUK", "NUR MD.SORDER", "PARVEJ"} ;
    // Start is called before the first frame update
    private void Awake() {
        body = GetComponent<Rigidbody2D>() ;
        // anim = GetComponent<Animator>() ;
    }

    // Update is called once per frame
    private void Update() {
        if (gameRun) {
            float horizontalInput = Input.GetAxis("Horizontal") ;
            float verticalInput = Input.GetAxis("Vertical") ;
            // if (horizontalInput !=0) {verticalInput = 0 ;}
            // else if (verticalInput != 0) {horizontalInput = 0 ;}
            // if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            // {
            //     speed += 10 ;
            // }
            body.velocity = new Vector2(horizontalInput*speed,verticalInput*speed);
            
            // flip player x
            // if (horizontalInput > 0.01f) {
            //     transform.rotation = Quaternion.Euler(0, 0, 270);
            // }
            // else if (horizontalInput < -0.01f) {
            //     transform.rotation = Quaternion.Euler(0, 0, 90);
            // }

            // flip player y
            if (verticalInput > 0.01f) {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (verticalInput < -0.01f) {
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            if (shoot == 0) {shoot = 3 ; life -=1; shootText.text = "Shoot: |||" ;}
            if (shoot == 1) {shootText.text = "Shoot: |" ;}
            if (shoot == 2) {shootText.text = "Shoot: ||" ;}
            if (life == 3) {lifeText.text = "Life: 000" ;}
            else if (life == 2) {lifeText.text = "Life: 00" ;}
            else if (life == 1) {lifeText.text = "Life: 0" ;}
            else if (life == 0) {lifeText.text = "Life: " ; gameRun = false;}
            scoreText.text = "Score: " + score.ToString() ;
            // if (horizontalInput != 0 || verticalInput != 0) {anim.SetBool("run", true) ;}
            // else if (horizontalInput == 0 || verticalInput == 0) {anim.SetBool("run", false) ;}
        }
        else {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "SafeSpot") {
            transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);  // Scale down uniformly
        }

        else if(collision.gameObject.tag == "Bullet") {            
            shoot -= 1 ;
        }
        else if(collision.gameObject.tag == "StudentRun") {
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true ;
            score += 1 ;
            martyrText.text = "My hero is " + martyr[Random.Range(0, 18)] ;
        }
        else if(collision.gameObject.tag == "FinishLine") {
            SceneManager.LoadScene("FinishLineScene");
        }
    }

    void OnCollisionExit2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "SafeSpot") {
            transform.localScale = new Vector3(0.5f, 1.0f, 1.0f);  // Scale down on the y-axis only
        }        
    }

}
