using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotateSpead = 5f;
    [SerializeField]private GameInput gameInput;
    
    private bool isWalking;
    private void Update()
    {
        Vector2 inputvector = gameInput.getmovement();
        Vector3 movementvector = new Vector3(inputvector.x * moveSpeed, 0f, inputvector.y * moveSpeed);
        transform.position += movementvector * Time.deltaTime * moveSpeed;

        isWalking=(movementvector!=Vector3.zero);
        
        // transform.LookAt(transform.position + movementvector, Vector3.up);
        transform.forward = Vector3.Slerp(transform.forward, movementvector, Time.deltaTime * rotateSpead);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}