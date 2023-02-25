using Interfaces;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour, IPlayerMove
    {
        [SerializeField] private float speed;
        [SerializeField] private Vector2 distance;
        [SerializeField] private float swipeSpeed = 0.01f;
        public void Move()
        {
            Touch touchInput = Input.GetTouch(0);
            if (touchInput.phase == TouchPhase.Moved && (transform.position.x > distance.x && transform.position.x < distance.y))
            {
                transform.position = new Vector3(transform.position.x + touchInput.deltaPosition.x * swipeSpeed, transform.position.y, transform.position.z);
            }
            if (transform.position.x <= distance.x)
            {
                transform.position = new Vector3(distance.x + .01f, transform.position.y, transform.position.z);
            }
            if (transform.position.x >= distance.y)
            {
                transform.position = new Vector3(distance.y - .01f, transform.position.y, transform.position.z);
            }
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }
}
