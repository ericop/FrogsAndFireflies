using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RedFrogBehavior : MonoBehaviour
{
    int score = 0;
	private Vector3 initialPosition;
	private Quaternion initialRotation;
   
    public GameObject WinSoundsPrefab;
    // Use this for initialization
    void Start()
    {
		initialPosition = transform.position;
		initialRotation = transform.rotation;

        var character = GetComponent<Rigidbody2D>();
        var opponentFrog = GameObject.FindWithTag("BlueFrog");
        Physics2D.IgnoreCollision(character.GetComponent<Collider2D>(), opponentFrog.GetComponent<Collider2D>());

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == ("FireflyClone"))
        {
            Debug.Log("Fred hitting stuff " + coll.gameObject.tag == ("FireflyClone") + "count = " + score);
            var fireflyThatWeHit = coll.gameObject;
            Destroy(fireflyThatWeHit);
            score += 1;
            var redScore = GameObject.FindWithTag("RedScore").GetComponent<Text>();
            redScore.text = "Red Fred's Score: " + score + "/20";

            if (score >= 20)
            {
                StartCoroutine("YouWin");
            }
        }
			
    }

    // Update is called once per frame
    void Update()
    {
        var character = GetComponent<Rigidbody2D>();
        if (character.velocity.y == 0)
        {
            GetComponent<Animator>().speed = 0;
        }
        if (character.velocity.y > 0)
        {
            GetComponent<Animator>().speed = 3.5f;
        }
        if (character.velocity.y < 0)
        {
            GetComponent<Animator>().speed = 1.5f;
        }

        if (Input.GetKey(KeyCode.Return))
        {
            Leap();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void Leap()
    {
        Vector2 position = transform.position;
        var character = GetComponent<Rigidbody2D>();
        var startSide = character.position.x > 0 ? "right" : "left";
		if (character.position.y > -2.3)
        {
            if (startSide == "right")
            {
                Vector2 jumpLeft = new Vector2(-3, 14);
                character.AddForce(jumpLeft * 0.55f);
            }
            if (startSide == "left")
            {
                Vector2 jumpRight = new Vector2(3, 14);
				character.AddForce(jumpRight * 0.55f);
            }
        }
		if (character.velocity == new Vector2(0, 0) && character.position.y <= -2.5 )
		{
			var ribbit = GameObject.FindWithTag("RedRibbitAudio").GetComponent<AudioSource>();
			ribbit.Play();
			if (startSide == "right")
			{
				Vector2 jumpLeft = new Vector2(-3, 14);
				character.AddForce(jumpLeft * 18.5f);
			}
			if (startSide == "left")
			{
				Vector2 jumpRight = new Vector2(3, 14);
				character.AddForce(jumpRight * 18.5f);
			}
		}
    }

	void OnBecameInvisible() 
	{
		RebootPosition ();
	}

	public void RebootPosition ()
	{
		transform.rotation = initialRotation;
		transform.position = initialPosition;
		var character = GetComponent<Rigidbody2D>();
		character.velocity = new Vector2 (0, 0);
	}

    IEnumerator YouWin()
	{
        var character = GetComponent<Rigidbody2D>();
        // Play sound
        Instantiate(WinSoundsPrefab, character.position, Quaternion.identity);
		//var redFredWinsAudio = GameObject.FindWithTag("RedFredWinsAudio").GetComponent<AudioSource>();
		//redFredWinsAudio.Play();
        var winnerText = GameObject.FindWithTag("WinnerIs").GetComponent<Text>();
        winnerText.text = "Red Fred Wins!";
        yield return new WaitForSeconds(2.2f);
        SceneManager.LoadScene("splash");
    }

}
