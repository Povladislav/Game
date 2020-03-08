using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{
    public static GManager instanse = null;
    public List<Enemy> enemyList = new List<Enemy>();

    [SerializeField]
    private int totalWaves;
    [SerializeField]
    private Text totalMoneyLbl;
    [SerializeField]
    private Text currentWaveLbl;
    [SerializeField]
    private Text playBtnLbl;
    [SerializeField]
    private Text totalEscapedLbl;
    [SerializeField]
    private GameObject spawnPoint;
    [SerializeField]
    private GameObject[] enemies;
    [SerializeField]
    private int maxEnemiesOnScreen;
    [SerializeField]
    private int totalEnemies;
    [SerializeField]
    private int enemiesPerSpawn;

    private int waveNumber = 0;
    private int totalMoney = 10;
    private int totalEscaped;
    private int roundEscaped;
    private int totalKilled = 0;
    private int whichEnemiesToSpawn;
    private void Awake()
    {
        if (instanse == null)
            instanse = this;
        else if (instanse != this)
            Destroy(gameObject);
    }




    IEnumerator Spawn()
    {
        if (enemiesPerSpawn > 0 && enemyList.Count < totalEnemies)
        {
            for (int i = 0; i < enemiesPerSpawn; i++)
            {
                if (enemyList.Count < maxEnemiesOnScreen)
                {
                    GameObject newEnemy = Instantiate(enemies[0]) as GameObject;
                    newEnemy.transform.position = spawnPoint.transform.position;
                }


            }
        }
        yield return new WaitForSeconds(0.7f);
        StartCoroutine(Spawn());
    }
    public void RegisterEnemy(Enemy enemy)
    {
        enemyList.Add(enemy);
    }
    public void UnRegisterEnemy(Enemy enemy)
    {
        enemyList.Remove(enemy);
        Destroy(enemy.gameObject);
    }
    public void DestroyAllEnemies()
    {
        foreach (var enemy in enemyList)
        {
            Destroy(enemy.gameObject);
        }
        enemyList.Clear();
    }
    private void Start()
    {
        StartCoroutine(Spawn());
    }
}
