using UnityEngine;

public class RoadGround : MonoBehaviour
{
    public GameObject road;
    public Vector3 lastPos;
    public float offset = 1f;
    public float roadCount = 1f;

    void Start()
    {
        InvokeRepeating("NewRoadCreate", 0f, 0.3f);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            NewRoadCreate();
        }
    }

    public void NewRoadCreate()
    {
        Vector3 spawnPos = Vector3.zero;
        float chance = UnityEngine.Random.Range(0,100);

        if(chance < 50)
        spawnPos = new Vector3(lastPos.x + offset, lastPos.y, lastPos.z + offset);
        else
        spawnPos= new Vector3(lastPos.x - offset, lastPos.y, lastPos.z + offset);


        GameObject g = Instantiate(road, spawnPos, Quaternion.Euler(0,45,0));
        lastPos = g.transform.position;

        roadCount++;
        if(roadCount % 4 == 0)
        {
            g.transform.GetChild(0).gameObject.SetActive(true);

            if (g.CompareTag("Crystal"))
            {
                Transform crystalChild = g.transform.GetChild(0);

            }
        }
    }    
}
