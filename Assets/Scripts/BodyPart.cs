using UnityEngine;

public class BodyPart : MonoBehaviour {

    //private float minDistance = 30f;
    public GameObject Next;
    private BodyPart NextBodyPart;

    private void Start()
    {
        if(Next!=null)
            NextBodyPart = Next.GetComponent<BodyPart>();
    }

    public void UpdatePosition(Transform prevTransform, float speedlocal)
    {
        var mypos = new Vector2(transform.position.x, transform.position.y);
        var newPos = prevTransform.position;

        transform.position = Vector2.Lerp(mypos, newPos, speedlocal * 1.9f);
        transform.rotation = Quaternion.Lerp(transform.rotation, prevTransform.rotation, speedlocal * 1.9f);

        if (NextBodyPart != null)
            NextBodyPart.UpdatePosition(transform,speedlocal);
    }

    public void SetNext(GameObject next) {
        NextBodyPart = next.GetComponent<BodyPart>();
    }
}
