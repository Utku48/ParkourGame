using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashAudio : MonoBehaviour
{
    public AudioSource ses;
    public int puan = 0;

    void Start()
    {
        ses = GetComponent<AudioSource>();
    }


    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CheckPoint"))
        {
            ses.Play();
            puan += 10;
            Debug.Log("puan");
            Destroy(collision.gameObject);
        }

    }
    private void OnGUI()
    {
        GUI.color = Color.black;
        GUI.Box(new Rect(20, 20, 100, 50), puan.ToString());
    }



}
