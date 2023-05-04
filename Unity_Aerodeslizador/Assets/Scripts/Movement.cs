using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float leftBound = -8f;
    public float rightBound = 8f;
    
    private bool rightMove = true;
    
    void Update()
    {
        if (transform.position.x <= leftBound)
        {
            rightMove = true;
        }
        else if (transform.position.x >= rightBound)
        {
            rightMove = false;
        }
        
        if (rightMove)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}