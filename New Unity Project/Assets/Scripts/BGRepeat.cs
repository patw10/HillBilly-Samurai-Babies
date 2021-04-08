using UnityEngine;

public class BGRepeat : MonoBehaviour
{
    public float speed;
    public float endx;
    public float startx;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= endx)
        {
            Vector2 pos = new Vector2(startx, transform.position.y);
            transform.position = pos;
        }
    }
}