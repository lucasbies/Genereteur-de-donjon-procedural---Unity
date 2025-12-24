using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;


public class DungeonGenerator : MonoBehaviour
{
    [Header("Dungeon Settings")]
    public int seed;
    public int nbRooms;
    public int nbEnemies;
    public int nbCoins;

    [Header("Room Prefabs")]
    [SerializeField] private List<RoomInstance> _roomPrefab;
    [SerializeField] private GameObject _roomStart;
    [SerializeField] private GameObject _roomEnd;

    [Header("Parents")]
    [SerializeField] private Transform _roomParent;
    [SerializeField] private Transform _enemiesParent;
    [SerializeField] private Transform _coinsParent;

    private List<DataRoom> _rooms;
    private List<DataRoom> _roomsEnemies;
    private List<DataRoom> _roomsCoins;
    private List<GameObject> _doorPosAvailable;


    private void Awake()
    {
        _rooms = new List<DataRoom>();
        _roomsEnemies = new List<DataRoom>();
        _roomsCoins = new List<DataRoom>();
        _doorPosAvailable = new List<GameObject>();
    }

    private void Start()
    {
        
        GenerateDungeon();
    }

    // Ajouter une room dans les listes appropriées
    private void AddRoomInList(DataRoom room)
    {
        _rooms.Add(room);
        if (room.EnemyPositions.Count > 0)
            _roomsEnemies.Add(room);
        if (room.CoinPositions.Count > 0)
            _roomsCoins.Add(room);
        _doorPosAvailable.AddRange(room.GetDoorPos());
    }

    // Générer le donjon
    public void GenerateDungeon()
    {
        ClearDungeon();

        Debug.Log("Generating Dungeon...");
        Random.InitState(seed);

        GameObject newRoom = GameObject.Instantiate(_roomStart, new Vector3(0, 0, 0), Quaternion.identity, _roomParent);
        AddRoomInList(newRoom.GetComponent<DataRoom>());
        GenerateRooms();
        if(_roomEnd != null)
        {
            GenerateRoomEnd();
        }
        ReactiveWall();
        GenerateCoins();
        GenerateEnemies();
    }


    // Générer les rooms principales
    private void GenerateRooms()
    {
        int nbFailedAttempts = 0;

        int totalProbability = 0;
        foreach (var room in _roomPrefab)
        {
            totalProbability += room.probability;
        }
        for (int i = 0; i < nbRooms; i++)
        {
            if (_doorPosAvailable.Count == 0)
                break;
            GameObject doorObj = _doorPosAvailable[Random.Range(0, _doorPosAvailable.Count)];
            Transform doorTransform = doorObj.transform;
            bool roomPlaced = false;

            for (int j = 0; j < 20 && !roomPlaced; j++)
            {
                // selectionner une room aléatoire en fonction de sa probabilité
                RoomInstance selectedRoom = GetRandomRoomByProbability(totalProbability);

                GameObject roomPrefab = selectedRoom.roomObject;

                // Créer une preview de la room à la position de la porte
                GameObject preview = Instantiate(roomPrefab, doorTransform.position, doorTransform.rotation, _roomParent);
                DataRoom dr = preview.GetComponent<DataRoom>();
                Bounds localBounds = dr.GetBounds();


                // Calculer les bounds en coordonnées monde
                Bounds worldBounds = dr.GetBounds();
                worldBounds.center = preview.transform.TransformPoint(localBounds.center);

                if (CanPlaceRoom(worldBounds))
                {
                    AddRoomInList(dr);
                    _doorPosAvailable.Remove(doorObj);

                    roomPlaced = true;
                }
                else
                    Destroy(preview);
            }
            // Si la room n'a pas pu être placée, réactiver le mur et retirer cette porte des possibilités
            if (!roomPlaced)
            {
                nbFailedAttempts++;
                Transform wall = doorObj.transform.GetChild(0); 
                wall.gameObject.SetActive(true);
                _doorPosAvailable.Remove(doorObj);
            }
        }
        Debug.Log($"Room generation complete with {nbFailedAttempts} failed attempts for {nbRooms} rooms. Rooms generated : {((float)(nbRooms - nbFailedAttempts) / (float)nbRooms) * 100}%");
    }


    // Générer la room de fin
    private void GenerateRoomEnd()
    {
        bool roomPlaced = false;

        GameObject roomPrefab = _roomEnd;

        GameObject preview = Instantiate(roomPrefab, _roomParent);
        DataRoom dr = preview.GetComponent<DataRoom>();
        Bounds localBounds = dr.GetBounds();
        // Essayer de placer la room sur chaque porte disponible en partant de la fin
        for (int i=_doorPosAvailable.Count -1 ; i>=0 && !roomPlaced; i--)
        {
            GameObject doorObj = _doorPosAvailable[i];
            Transform doorTransform = doorObj.transform;

            // Positionner la preview en fonctione de la porte
            preview.transform.position = doorTransform.position;
            preview.transform.rotation = doorTransform.rotation;

            // Calculer les bounds en coordonnées monde
            Bounds worldBounds = dr.GetBounds();
            worldBounds.center = preview.transform.TransformPoint(localBounds.center);

            if (CanPlaceRoom(worldBounds))
            {
                // Utiliser la position calculée pour la vraie room
                AddRoomInList(dr);
                _doorPosAvailable.Remove(doorObj);

                roomPlaced = true;
            }
            
        }
        if(!roomPlaced)
        {
            Debug.LogWarning($"Failed to place end room, no available door");
            Destroy(preview);
        }
            
    }


    // Réactiver les murs des portes non utilisées
    private void ReactiveWall()
    {
        foreach (GameObject door in _doorPosAvailable)
        {
            Transform wall = door.transform.GetChild(0); // un seul enfant

            if (wall != null)
                wall.gameObject.SetActive(true);
        }
    }


    // Générer les room avec des coins
    private void GenerateCoins()
    {
        for (int i = 0; i < nbCoins; i++)
        {
            if (_roomsCoins.Count == 0)
            {
                Debug.Log("No more rooms available for coins.");
                break;
            }

            int randomIndexRoom = Random.Range(0, _roomsCoins.Count);
            DataRoom selectedRoom = _roomsCoins[randomIndexRoom];
            selectedRoom.SpawnCoins(_coinsParent);
            if (selectedRoom.CoinPositions.Count <= 0)
            {
                _roomsCoins.RemoveAt(randomIndexRoom);
            }
            
        }
    }


    // Générer les room avec des ennemis
    private void GenerateEnemies()
    {
        for (int i = 0; i < nbEnemies; i++)
        {
            if (_roomsEnemies.Count == 0)
            {
                Debug.Log("No more rooms available for enemies.");
                break;
            }
            int randomIndexRoom = Random.Range(0, _roomsEnemies.Count);
            DataRoom selectedRoom = _roomsEnemies[randomIndexRoom];
            selectedRoom.SpawnEnemies(_enemiesParent);
            if (selectedRoom.EnemyPositions.Count <= 0)
            {
                _roomsEnemies.RemoveAt(randomIndexRoom);
            }
        }
    }


    // Vérifier si une room peut être placée à l'emplacement donné
    private bool CanPlaceRoom(Bounds newRoom)
    {
        Bounds testBounds = newRoom;
        testBounds.Expand(-0.1f);
        foreach (DataRoom placedRoom in _rooms)
        {
            Bounds placedBounds = placedRoom.GetBounds();
            placedBounds.center = placedRoom.transform.TransformPoint(placedBounds.center);

            if (placedBounds.Intersects(testBounds))
                return false;
        }
        return true;
    }


    // Vider le donjon
    private void ClearDungeon()
    {
        foreach (Transform child in _roomParent)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in _enemiesParent)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in _coinsParent)
        {
            Destroy(child.gameObject);
        }
        _rooms.Clear();
        _roomsEnemies.Clear();
        _roomsCoins.Clear();
        _doorPosAvailable.Clear();
    }

    // Sélectionner une room aléatoire en fonction de sa probabilité
    private RoomInstance GetRandomRoomByProbability(int totalProbability)
    {
        int randomValue = Random.Range(0, totalProbability);
        foreach (var room in _roomPrefab)
        {
            if (randomValue < room.probability)
            {
                return room;
            }
            randomValue -= room.probability;
        }
        return default;
    }
}