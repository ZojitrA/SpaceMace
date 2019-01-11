using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1.2f;
    [SerializeField] float maxX = 14.8f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float controlledMousePos = Mathf.Clamp(GetXPos(), minX, maxX);
        Vector2 paddlePos = new Vector2(controlledMousePos, transform.position.y);
        transform.position = paddlePos;
	}

    private float GetXPos()
    {
        if (FindObjectOfType<GameSession>().AutoPlayEnabled())
        {
            return FindObjectOfType<Ball>().transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
