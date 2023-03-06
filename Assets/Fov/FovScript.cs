using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FovScript : MonoBehaviour
{
    [SerializeField] private GameObject beamPrefab;
    [SerializeField] private int numberOfBeams;
    [SerializeField] private float angel;
    [SerializeField] private PlayerScript player;
    private List<GameObject> beams = new List<GameObject>();
    void Start()
    {

        float angelPart = angel / numberOfBeams;
        float currentAngelL = 90, currentAngelR = 90;
        GameObject beam = Instantiate(beamPrefab, transform);
        beam.transform.eulerAngles = new Vector3(0, 0, currentAngelR);
        for (int i = 1; i< numberOfBeams / 2; i++)
        {
            currentAngelL -= angelPart;
            currentAngelR += angelPart;

            beam = Instantiate(beamPrefab, transform);
            beam.transform.eulerAngles = new Vector3(0, 0, currentAngelR);
            beams.Add(beam);

            beam = Instantiate(beamPrefab, transform);
            beam.transform.eulerAngles = new Vector3(0, 0, currentAngelL);
            beams.Add(beam);



        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = player.getDir().normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        if (n < 0) n += 360;
        transform.eulerAngles = new Vector3(0, 0, n);
    }
}
