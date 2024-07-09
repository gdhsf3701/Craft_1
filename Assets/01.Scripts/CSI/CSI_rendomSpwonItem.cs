using System.Collections;
using UnityEngine;


public class CSI_rendomSpwonItem : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    private Vector2 Center;
    private Vector2 SIze;
    private Vector2 GOPosition;
    public GameObject[] GameObjects;
    private void Awake()
    {
        _boxCollider = gameObject.GetComponent<BoxCollider2D>();
        Center = _boxCollider.offset;
        SIze = _boxCollider.size;
        GOPosition = transform.position;
        StartCoroutine(update(2f));

    }

    IEnumerator update(float Timer)
    {
        while (true)
        {
            int ranobj = Random.Range(0,GameObjects.Length);
            float ranx = Random.Range(GOPosition.x + Center.x - SIze.x/2,GOPosition.x + Center.x + SIze.x/2);
            float rany = Random.Range(GOPosition.y + Center.y- SIze.y/2,GOPosition.y + Center.y + SIze.y/2);
            print(ranobj);
            Instantiate(GameObjects[ranobj]).transform.position = new Vector2(ranx, rany);

            yield return new WaitForSeconds(Timer);
        }
        
    }
}
