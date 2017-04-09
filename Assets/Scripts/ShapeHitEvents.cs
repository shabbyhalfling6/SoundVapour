using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeHitEvents : MonoBehaviour {

    private int hitCount = 0;

    private int standardScore = 20;
    private int goodScore = 50;
    private int perfectScore = 75;

    void OnParticleCollision (GameObject shape)
	{
		if (PlayerInput.selectedShape == shape.gameObject.tag) 
		{
            //destroy the shape that was hit
            Destroy(shape.gameObject);

            //increment the hitCount
            hitCount++;

            //NOTE: temporary score setting, replace with detecting perfects and goods
            int score = standardScore;
            //call the RewardScore function in the PlayerScore class to update the currentScore
            PlayerScore.Instance.RewardScore(hitCount, score);
        }
	}
}
