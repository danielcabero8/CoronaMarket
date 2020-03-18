using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TouchMotion : MonoBehaviour
{
    [SerializeField]
    private GameObject TouchRegion;

    // Update is called once per frame
    void Update()
    {
        BoxCollider2D collider = TouchRegion.GetComponent<BoxCollider2D>();

        Touch[] touches = Input.touches;
        IEnumerable<Touch> FilteredTouches = touches.AsQueryable().Where
        (
            touch => collider.OverlapPoint(Camera.main.ScreenToWorldPoint(touch.position))
        );

        //If there is contact
        if(FilteredTouches.Count() == 1)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(FilteredTouches.First().position);
            Vector3 directionVector = touchPosition - transform.position;
            Vector2 forceUnit = new Vector2(directionVector.x, 0.0f);
            forceUnit.Normalize();

            Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();

            //check if new force is in the contrary direction
            if((forceUnit.x > 0.0f && rigidBody.velocity.x < 0.0f)
            || (forceUnit.x < 0.0f && rigidBody.velocity.x > 0.0f))
            {
                //then reset horizontal velocity
                rigidBody.velocity = new Vector2();
            }

            rigidBody.AddForce(forceUnit * 6);
        }
    }
}
