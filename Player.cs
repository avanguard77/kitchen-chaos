using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotateSpeed = 5f;
    [SerializeField] private GameInput gameInput;

    private bool isWalking;

    private void Update()
    {
        Vector2 inputVector = gameInput.getmovement();
        Vector3 movementVector = new Vector3(inputVector.x, 0f, inputVector.y).normalized;

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerHeight = 3f;
        float playerRadius = 0.7f;

        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight,
            playerRadius, movementVector, moveDistance);

        if (!canMove)
        {
            Vector3 moveVectorX = new Vector3(movementVector.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight,
                playerRadius, moveVectorX, moveDistance);
            if (canMove)
            {
                movementVector = moveVectorX;
            }
            else
            {
                Vector3 moveVectorZ = new Vector3(0, 0, movementVector.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight,
                    playerRadius, moveVectorZ, moveDistance);
                if (canMove)
                {
                    movementVector = moveVectorZ;
                }
            }
        }

        if (canMove)
        {
            transform.position += movementVector * moveDistance;
        }

        isWalking = (movementVector != Vector3.zero);
        transform.forward = Vector3.Slerp(transform.forward, movementVector, Time.deltaTime * rotateSpeed);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}

