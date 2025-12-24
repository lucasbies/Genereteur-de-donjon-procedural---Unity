using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class DataRoom : MonoBehaviour
{
    [Header("Room Data Position")]
    [SerializeField] private List<GameObject> doorPosRoom;
    [SerializeField] private List<GameObject> enemiesPosRoom;
    [SerializeField] private List<GameObject> coinsPosRoom;


    //mettre en lecture seule
    public IReadOnlyList<GameObject> EnemyPositions => enemiesPosRoom;
    public IReadOnlyList<GameObject> CoinPositions => coinsPosRoom;



    [Header("Room Data Other Information")]
    [SerializeField]private List<GameObject> _enemiesPossible;
    [SerializeField]private GameObject _coins;
    [SerializeField] private BoxCollider boundsColliderRoom;


    // Spawn Enemies
    public void SpawnEnemies(Transform enemiesParent)
    {
        if ( _enemiesPossible.Count > 0 && enemiesPosRoom.Count >0)
        {
            int randomIndexEnemies = Random.Range(0, _enemiesPossible.Count);
            int randomIndexPosEnemies = Random.Range(0, enemiesPosRoom.Count);


            Instantiate(_enemiesPossible[randomIndexEnemies], enemiesPosRoom[randomIndexPosEnemies].transform.position, enemiesPosRoom[randomIndexPosEnemies].transform.rotation, enemiesParent);
            enemiesPosRoom.RemoveAt(randomIndexPosEnemies);
        }
    }


    // Spawn Coins
    public void SpawnCoins(Transform coinsParent)
    {
        if (coinsPosRoom.Count > 0)
        {
            int randomIndexPosCoins = Random.Range(0, coinsPosRoom.Count);
            Instantiate(_coins, coinsPosRoom[randomIndexPosCoins].transform.position, coinsPosRoom[randomIndexPosCoins].transform.rotation, coinsParent);
            coinsPosRoom.RemoveAt(randomIndexPosCoins);
        }
    }

    public List<GameObject> GetDoorPos()
    {
        return doorPosRoom;
    }


    public Bounds GetBounds()
    {
        return new Bounds( boundsColliderRoom.center, boundsColliderRoom.size);
    }


    // Gizmos pour visualiser les bounds de la room dans l'éditeur
    private void OnDrawGizmosSelected()
    {
        DataRoom dr = GetComponent<DataRoom>();
        if (dr == null) return;

        BoxCollider col = boundsColliderRoom;
        if (col == null) return;

        Gizmos.color = Color.cyan;

        Matrix4x4 oldMatrix = Gizmos.matrix;

        Gizmos.matrix = col.transform.localToWorldMatrix;
        Gizmos.DrawWireCube(col.center, col.size);

        Gizmos.matrix = oldMatrix;
    }


}
