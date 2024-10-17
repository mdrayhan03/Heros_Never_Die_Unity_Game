using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShootingStart : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI timeText ;
    public bool isShooting = false ;
    private float time = 0f ;
    private int t ;
    // Start is called before the first frame update
    void Start()
    {
    }

    void Update() {
        if (isShooting) {
            time += Time.deltaTime ;
            t = (int) time ;
            timeText.text = "Time: " + t.ToString() +"s";

            if (time >= 10f) {
                isShooting = false ;
            }
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") {
            timeText.gameObject.SetActive(true);
            isShooting = true ;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") {
            isShooting = false ;
            time = 0f ;
            timeText.gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "Bullet") {
            Destroy(other.gameObject) ;
        }
    }
}
