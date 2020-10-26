using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetDummyManager : MonoBehaviour
{
    [SerializeField] GameObject TargetDummyPrefab;
    [SerializeField] int NumTargets = 1;
    [SerializeField] Vector2Int XRange = new Vector2Int(1, 9);
    [SerializeField] Vector2Int YRange = new Vector2Int(1, 9);
    [SerializeField] float MaxStandTime = 5.0f;

    private GameObject[] TargetArray;

    [SerializeField] GameObject Text_Score;
    [SerializeField] GameObject Text_Shots;
    [SerializeField] GameObject Text_Targets;

    bool updateBoard = false;
    int numTargets;
    int numShots;

    // Start is called before the first frame update
    void Start()
    {
        TargetArray = new GameObject[ NumTargets ];

        if (NumTargets <= 0) NumTargets = 1;

        StartCoroutine(PopulateTargets());
    }

    // Update is called once per frame
    void Update()
    {
        if(updateBoard)
        {
            int tempShots = numShots;
            if (tempShots == 0) tempShots = 1;
            Text_Score.GetComponent<Text>().text = "Score: " + ((numTargets / tempShots) * 100);
            Text_Shots.GetComponent<Text>().text = "Shots: " + numShots;
            Text_Targets.GetComponent<Text>().text = "Targets: " + numTargets;

            updateBoard = false;
        }
    }

    public void TargetHit(GameObject targetDummy)
    {
        // Move up object's respawn timer

        // Increment score
    }

    IEnumerator PopulateTargets()
    {
        for( int i = 0; i < NumTargets; ++i )
        {
            GameObject tempObject = Instantiate( TargetDummyPrefab, transform );

            tempObject.GetComponent<TargetDummy>().NewPosition(GetXYPos(), MaxStandTime);

            TargetArray[i] = tempObject;

            numTargets++;
            updateBoard = true;

            yield return new WaitForSeconds(0.25f);
        }

        StartCoroutine( LoopTargetRespawns() );
    }

    IEnumerator LoopTargetRespawns()
    {
        while( true )
        {
            yield return new WaitForSeconds( MaxStandTime + 1.0f );

            for (int i = 0; i < NumTargets; ++i)
            {
                yield return new WaitForSeconds(0.25f);

                TargetArray[i].GetComponent<TargetDummy>().NewPosition( GetXYPos(), MaxStandTime );

                numTargets++;
                updateBoard = true;
            }
        }
    }

    Vector3 GetXYPos()
    {
        float xPos = Mathf.RoundToInt(Random.Range(XRange.x, XRange.y + 0.5f) / 0.5f) * 0.5f;
        float yPos = Mathf.RoundToInt(Random.Range(YRange.x, YRange.y + 0.5f) / 0.5f) * 0.5f;
        float zPos = 2f;

        return new Vector3(xPos, yPos, zPos);
    }

    public void IncrementShotsTaken()
    {
        numShots++;
        updateBoard = true;
    }
}
