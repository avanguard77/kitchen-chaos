using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotateSpead = 5f;
    [SerializeField] private GameInput gameInput;

    private bool isWalking;

    private void Update()
    {
        Vector2 inputvector = gameInput.getmovement();


        Vector3 movementvector = new Vector3(inputvector.x * moveSpeed, 0f, inputvector.y * moveSpeed);
        float moveDiraction = Time.deltaTime * moveSpeed;
        float playerhight = 2f;
        float playerradius = .7f;


        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerhight,
            playerradius, movementvector, moveDiraction);

        if (!canMove)
        {
            Vector3 moveVectorX = new Vector3(movementvector.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerhight,
                playerradius, moveVectorX, moveDiraction);
            if (canMove)
            {
                movementvector = moveVectorX.normalized;
            }
            else
            {
                Vector3 moveVectorZ = new Vector3(0, 0, movementvector.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerhight,
                    playerradius, moveVectorZ, moveDiraction);
                if (canMove)
                {
                    movementvector = moveVectorZ.normalized;
                }
            }
        }

        if (canMove)
        {
            transform.position += movementvector * moveDiraction;
        }

        isWalking = (movementvector != Vector3.zero);

        // transform.LookAt(transform.position + movementvector, Vector3.up);
        transform.forward = Vector3.Slerp(transform.forward, movementvector, Time.deltaTime * rotateSpead);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}