using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;

    public bool isGrounded;

    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collider)
    {
        isGrounded = collider != null && (((1 << collider.gameObject.layer) & platformLayerMask) != 0);
    }

    // Update is called once per frame
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}
