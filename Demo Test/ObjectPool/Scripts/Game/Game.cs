using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Text scoreText;
    public Text notifText;

    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: "+score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        KillEvent.OnEventTrigger += KillEventTrigger;
    }

    private void OnDestroy()
    {
        KillEvent.OnEventTrigger -= KillEventTrigger;
    }

    IEnumerator IEDisplayNotif(string content)
    {
        notifText.text = content;
        notifText.gameObject.SetActive(true);
        notifText.color = new Color(notifText.color.r, notifText.color.g, notifText.color.b, 1f);
        yield return new WaitForSeconds(5.0f);
        for(float i = 1f; i>=0f; i-=Time.deltaTime)
        {
            notifText.color = new Color(notifText.color.r, notifText.color.g, notifText.color.b,i);
            yield return new WaitForEndOfFrame();
        }
    }

    private void KillEventTrigger(KillEventData data)
    {
        score++;
        scoreText.text = "Score: "+score;
        string notif = data.killer.name + " kill " + data.victim.name;
        StartCoroutine(IEDisplayNotif(notif));

    }
}
