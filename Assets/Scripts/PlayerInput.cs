using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerInput : MonoBehaviour
{
	public string selectedShape;
    private float horizontalDialSelection;
    private float verticalDialSelection;
	private int standardScore = 20;
	private GameObject pauseMenu;
    private Animator anim;
	public static bool isPaused;
    private bool destroyedShape = false;
	public Vector2 inputVector;

    public BoxCollider2D box;

	public GameObject Vapour;   //<<< Particle System Zac is working on

    public float lastFrameButtonState = 0.0f;

	public AudioSource pauseSound;

	void Start()
	{
        anim = this.GetComponentInChildren<Animator>();
		pauseMenu = GameObject.Find ("PauseMenu");
		pauseMenu.SetActive (false);
	}

    void Update()
    {
        anim.SetBool("Vapourise", false);

        horizontalDialSelection = Input.GetAxisRaw("Horizontal");
        verticalDialSelection = Input.GetAxisRaw("Vertical");

		inputVector.x = horizontalDialSelection;
		inputVector.y = verticalDialSelection;
		inputVector.Normalize ();

		float vectorMagnitude = 0.7f;

		if (Vapourise())
        {
            anim.SetBool("Vapourise", true);
        }

        //Dial selection is nested under isPaused bool to prevent the dial selection from occuring in the pause menu
        if (isPaused == false && UIController.inst != null)
        {
			if ((inputVector.x <= -vectorMagnitude))
            {
                selectedShape = "Square";
                UIController.inst.LeftDialSelect.SetActive(true);
                UIController.inst.RightDialSelect.SetActive(false);
                UIController.inst.UpperDialSelect.SetActive(false);
                UIController.inst.BottomDialSelect.SetActive(false);
            }
			else if ((inputVector.x >= vectorMagnitude))
            {
                selectedShape = "Circle";
                UIController.inst.RightDialSelect.SetActive(true);
                UIController.inst.UpperDialSelect.SetActive(false);
                UIController.inst.LeftDialSelect.SetActive(false);
                UIController.inst.BottomDialSelect.SetActive(false);
            }
			else if ((inputVector.y <= -vectorMagnitude))
            {
                selectedShape = "X";
                UIController.inst.BottomDialSelect.SetActive(true);
                UIController.inst.UpperDialSelect.SetActive(false);
                UIController.inst.LeftDialSelect.SetActive(false);
                UIController.inst.RightDialSelect.SetActive(false);
            }
			else if ((inputVector.y >= vectorMagnitude))
            {
                selectedShape = "Triangle";
                UIController.inst.UpperDialSelect.SetActive(true);
                UIController.inst.LeftDialSelect.SetActive(false);
                UIController.inst.RightDialSelect.SetActive(false);
                UIController.inst.BottomDialSelect.SetActive(false);
            }
            else
            {
                selectedShape = string.Empty;
                UIController.inst.LeftDialSelect.SetActive(false);
                UIController.inst.RightDialSelect.SetActive(false);
                UIController.inst.BottomDialSelect.SetActive(false);
                UIController.inst.UpperDialSelect.SetActive(false);
            }

        }

        //If player hits the pause button, it activates the menu and pauses gameplay.
		if (Input.GetButtonDown("Pause") && (GameController.Instance.win == false && GameController.Instance.lose == false))
        {
            pauseToggle();
        }

        if(Vapourise())
        {
            var res = Physics2D.OverlapBoxAll(box.offset + (Vector2)transform.position, box.size, 0);

            for (int i = 0; i < res.Length; i++)
            {
                if(res[i] != box)
                {
                    var collider = res[i];

                    //if the shape passing the line is the selected shape...
                    if (collider.gameObject.tag == selectedShape)
                    {
                        //destroy the shape
                        Destroy(collider.gameObject);

                        destroyedShape = true;

						GameObject effectIns = (GameObject)Instantiate(Vapour, collider.transform.position, Quaternion.identity); // Zac is working on this
                        Destroy(effectIns, 0.7f);     //<< Zac is working on this

						ParticleSystem ps = effectIns.GetComponent <ParticleSystem> ();

						//grab the main base color
						var m = ps.main;
						//m.startColor = Color.red;


						//Change the color of the particle effect to match the shaped that is vapourised 
						if (collider.gameObject.tag == "Square")
						m.startColor = Color.red;
						
						if (collider.gameObject.tag == "X")
						m.startColor = Color.green;
						
						if (collider.gameObject.tag == "Circle")
						m.startColor = Color.blue;

						if (collider.gameObject.tag == "Triangle")
						m.startColor = Color.yellow;
						

                        //NOTE: temporary score setting, replace with detecting perfects and goods
                        int score = standardScore;
                        //call the RewardScore function in the PlayerScore class to update the currentScore
                        PlayerScore.Instance.RewardScore(1, score);
                    }
                }
            }
        }

        if (Vapourise() && !destroyedShape)
        {
            PlayerScore.Instance.hitCount = 0;
        }
    }

    private void LateUpdate()
    {
        lastFrameButtonState = Input.GetAxisRaw("Vapourise");
        destroyedShape = false;
    }

	public void pauseToggle()
	{
		pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
		Debug.Log("Pause Button Hit");
		if (pauseMenu.activeInHierarchy) 
		{
			Time.timeScale = 0;
			isPaused = true;
			pauseSound.Play();
		} 
		else 
		{
			Time.timeScale = 1;
			isPaused = false;
		}
	}

    void OnTriggerExit2D(Collider2D other)
    { 
        other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        other.gameObject.GetComponent<ShapeMoveController>().enabled = false;
        other.gameObject.tag = "Shape";
    }

   bool Vapourise ()
    {
        return (lastFrameButtonState == 0 && Input.GetAxisRaw("Vapourise") == 1);
    }
}
