using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    [SerializeField] Transform handTransform;
    [SerializeField] UnitController unitPrefab;
    [SerializeField] Transform heroPowerTransform;
    [SerializeField] GameObject heroPowerPrefab;
    [SerializeField] Transform chargedCostTransform;
    [SerializeField] GameObject chargedCostPrefab;
    private int heroPowerChargeTime = 2; // Hero modelから引っ張ってくる必要がある
    private int costChargeTime = 2; // Hero modelから引っ張ってくる必要がある

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        for (int i = 0; i < 3; i++)
        {
            DealCard();
        }
    }

    public void DealCard()
    {
        // unitかmagicかtrapかの判定を行う必要がある
        UnitController unit = Instantiate(unitPrefab, handTransform);
        unit.Init(0);
    }

    private float heroPowerTimer = 0.0f;
    private float costCargeTimer = 0.0f;
    // Update is called once per frame
    void Update()
    {
        heroPowerTimer += Time.deltaTime;
        costCargeTimer += Time.deltaTime;


        if (heroPowerTimer > heroPowerChargeTime)
        {
            Debug.Log("loop!");
            Instantiate(heroPowerPrefab, heroPowerTransform);
            heroPowerTimer = heroPowerTimer - heroPowerChargeTime;
        }

        if(costCargeTimer > costChargeTime)
        {
            Instantiate(chargedCostPrefab, chargedCostTransform);
            costCargeTimer = costCargeTimer - heroPowerChargeTime;
        }
    }
}
