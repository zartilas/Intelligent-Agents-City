using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    internal Transform thisTransform;
    public List<Vector3> listOfPositions = new List<Vector3>();
    Vector3 nextPotision;
    Vector3 positions;

    // The movement speed of the object
    public float moveSpeed = 0.5f;

    // A minimum and maximum time delay for taking a decision, choosing a direction to move in
    public Vector2 decisionTime = new Vector2(1, 4);
    internal float decisionTimeCount = 0;

    // The possible directions that the object can move int, right, left, up, down, and zero for staying in place. I added zero twice to give a bigger chance if it happening than other directions
    internal Vector3[] moveDirections = new Vector3[] { Vector3.right, Vector3.left, Vector3.up, Vector3.down};
    internal int currentMoveDirection;

    // Use this for initialization
    void Start()
    {
        positions = transform.position;
        // Cache the transform for quicker access
        thisTransform = this.transform;

        // Set a random time delay for taking a decision ( changing direction, or standing in place for a while )
        decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);

        // Choose a movement direction, or stay in place
        //Potision();
        ChooseMoveDirection();
    }

    // Update is called once per frame
    void Update()
    {

        // Move the object in the chosen direction at the set speed
        thisTransform.position += moveDirections[currentMoveDirection] * Time.deltaTime * moveSpeed;

        if (decisionTimeCount > 0) decisionTimeCount -= Time.deltaTime;
        else
        {
          
           // Choose a random time delay for taking a decision ( changing direction, or standing in place for a while )
           decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);

           //Choose a movement direction, or stay in place
           ChooseMoveDirection();
           //CheckPosition();
        }
    }


    public int ChooseMoveDirection()
    {
        // Choose whether to move sideways or up/down
        currentMoveDirection = Mathf.FloorToInt(Random.Range(0, moveDirections.Length));
        /* 
         * Debug.Log("THE CURRENT " + currentMoveDirection.ToString());
         * Debug.Log("VECTOR right  " + Vector3.right);
         * Debug.Log("VECTOR up " + Vector3.up);
         * Debug.Log("VECTOR left " + Vector3.left); Debug.Log("VECTOR down " + Vector3.down);
        */
        return currentMoveDirection;
    }

    void Potision()
    {
        
        int next = ChooseMoveDirection();

        switch (next)
        {
            case 0:
                nextPotision = transform.position + Vector3.right;
                Debug.Log("THE NEXT LOCATION R " + nextPotision.ToString());
                break;
            case 1:
                nextPotision = transform.position + Vector3.left;
                Debug.Log("THE NEXT LOCATION L " + nextPotision.ToString());
                break;
            case 2:
                nextPotision = transform.position + Vector3.up;
                Debug.Log("THE NEXT LOCATION U " + nextPotision.ToString());
                break;
            case 3:
                nextPotision = transform.position + Vector3.down;
                Debug.Log("THE NEXT LOCATION D " + nextPotision.ToString());
                break;
        }
 
    }

    void CheckPosition()
    {
        Potision();
        foreach (Vector3 position in listOfPositions)
        { 
            Debug.Log("Pos: " + position);
            if (!position.Equals(nextPotision))
            {
                Debug.Log(positions.ToString());
                listOfPositions.Add(nextPotision);
            }
        }
       
    }
}
