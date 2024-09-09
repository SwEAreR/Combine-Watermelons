using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public GameObject[] FruitPreFabs;

    public Transform FruitPosition;

    public GameObject ReadyFruit;

    private int maxRange = 0;
    public int MaxRange
    {
        get { return maxRange; }
        set { maxRange = value; }
    }
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        CreateFruit();
    }

    void Update()
    {
        MouseClick();
    }
    private void MouseClick()
    {
        if (ReadyFruit == null)
        {
            return;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 NewPos = new Vector3(MousePos.x, ReadyFruit.transform.position.y, ReadyFruit.transform.position.z);
            // 边界限制
            float max = 3f - ReadyFruit.GetComponent<CircleCollider2D>().radius;
            float min = -3f + ReadyFruit.GetComponent<CircleCollider2D>().radius;
            if (NewPos.x > max)
            {
                NewPos.x = max;
            }
            else if (NewPos.x < min)
            {
                NewPos.x = min;
            }
            ReadyFruit.transform.position = NewPos;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ReadyFruit.GetComponent<Rigidbody2D>().gravityScale = 1;
            Invoke("CreateFruit", 1f);
            ReadyFruit = null;
        }
    }
    private void CreateFruit()
    {
        int index = Random.Range(0, maxRange);
        GameObject prefab = FruitPreFabs[index];
        ReadyFruit = Instantiate(prefab);
        ReadyFruit.transform.position = FruitPosition.position;
        ReadyFruit.GetComponent<Rigidbody2D>().gravityScale = 0;
    }
}
