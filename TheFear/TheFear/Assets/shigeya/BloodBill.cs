using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBill : MonoBehaviour
{
    int childcount;
    int counter;
    float timer;
    float timeinterval;

    bool bloodflg;

    AudioSource sound1;

	// Use this for initialization
	void Start ()
    {
        childcount = transform.childCount;
        counter = 0;
        timer = 0.0f;
        timeinterval = 1.0f;
        sound1 = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            bloodflg = true;
        }

        if (timer > timeinterval && counter < childcount && bloodflg)
        {
            gameObject.transform.GetChild(counter).gameObject.SetActive(true);
            sound1.PlayOneShot(sound1.clip);
            timeinterval *= 0.8f;
            timer = 0.0f;
            counter++;
        }

        if (timer > 2.0f && counter > 2)
        {
            foreach(Transform n in gameObject.transform)
            {
                n.gameObject.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.05f);
            }
        }
        timer += Time.deltaTime;
	}
}
