using UnityEngine;

public class Pig : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ground>())
        {
            PigsManager.Instance.ReducePigsInPlayOnLevel();
            Destroy(this);
        }
    }
}
