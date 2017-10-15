using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlueFrogBehavior : MonoBehaviour
{
	int score = 0;
	private Vector3 initialPosition;
	private Quaternion initialRotation;
    Text blueScore;

    public GameObject WinSoundsPrefab;
    public bool isBattleMode;
    // Use this for initialization
    void Start()
	{
		initialPosition = transform.position;
		initialRotation = transform.rotation;
        blueScore = GameObject.FindWithTag("BlueScore").GetComponent<Text>();
        // Still Not needed, even RedFrog's IgnoreCollision is take care of in the RedFrogBehavior.Start()
        var character = GetComponent<Rigidbody2D>();
        var opponentFrog = GameObject.FindWithTag("RedFrog");


        if (!isBattleMode)
		{
			Physics2D.IgnoreCollision (character.GetComponent<Collider2D> (), opponentFrog.GetComponent<Collider2D> ());
		}
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == ("FireflyClone"))
        {
            var fireflyThatWeHit = coll.gameObject;
            Destroy(fireflyThatWeHit);
            score += 1;

			blueScore.text = "Blue Hugh's Score: " + score + "/20";
            if (score >= 20)
            {
				score = 0;
                StartCoroutine("YouWin");
            }
        }
    }

	void OnBecameInvisible() 
	{
		if (isBattleMode) 
		{
			if (score > 0)
			{
				score -= 1;
                blueScore.text = "Blue Hugh's Score: " + score + "/20 after fall";
            }
		}
		RebootPosition ();
	}

	public void RebootPosition ()
	{
		transform.rotation = initialRotation;
		transform.position = initialPosition;
		var character = GetComponent<Rigidbody2D>();
		character.velocity = new Vector2 (0, 0);
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
            GetComponent<Animator>().speed = 1f;
        }

        if (Input.GetKey(KeyCode.Space))
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
			var ribbit = GameObject.FindWithTag("BlueRibbitAudio").GetComponent<AudioSource>();
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

    IEnumerator YouWin()
    {
        var character = GetComponent<Rigidbody2D>();
        Instantiate(WinSoundsPrefab, character.position, Quaternion.identity);
        //var redFredWinsAudio = GameObject.FindWithTag("BlueHughWinsAudio").GetComponent<AudioSource>();
        //redFredWinsAudio.Play();
        var winnerText = GameObject.FindWithTag("WinnerIs").GetComponent<Text>();
        winnerText.text = "Blue Hugh Wins!";
        yield return new WaitForSeconds(2.2f);
        SceneManager.LoadScene("splash");
    }
}