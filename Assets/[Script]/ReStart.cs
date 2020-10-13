using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReStart : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Button GameOverButton;
    void Start()
    {
       GameOverButton.onClick.AddListener(()=>
       {
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
