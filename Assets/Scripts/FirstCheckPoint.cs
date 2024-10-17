using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FirstCheckPoint : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI studenttext ;
    private BoxCollider2D boxCollider2D ;
    private bool iscollider = false ;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>() ;
        studenttext.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (iscollider) {
            if (Input.GetKey(KeyCode.Space)) {
                studenttext.gameObject.SetActive(false);
                iscollider = false ;
            }
            else {
                studenttext.gameObject.SetActive(true);
            }
        }        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        studenttext.gameObject.SetActive(true);
        Destroy(boxCollider2D) ;
        iscollider = true ;
    }
}
