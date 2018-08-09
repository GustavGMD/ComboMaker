using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum Turn
{
    PLAYER = 0,
    ENEMY = 1
}

public class LevelManager : MonoBehaviour
{
    [Header("Map Fields")]
    public int mapHeight = 9;
    public int mapWidth = 16;

    [Header("Map Elements Prefabs")]
    public GameObject playerObject;
    public GameObject enemyObject;
    public GameObject obstacleObject;

    [Header("Other Gameplay Elements")]
    public InputManager inputManager;

    private Dictionary<Vector2Int, IMapElement> mapElements = new Dictionary<Vector2Int, IMapElement>();
    private IMapElement playerElement;
    private List<IMapElement> enemyElements;

    private Turn currentTurn = Turn.PLAYER;
    public Turn CurrentTurn
    {
        get
        {
            return currentTurn;
        }
        set
        {
            switch (value)
            {
                case Turn.PLAYER:
                    inputManager.gameObject.SetActive(true);
                    RepositionInputs();
                break;
                case Turn.ENEMY:
                    inputManager.gameObject.SetActive(false);
                    ProcessEnemyTurn();
                    break;
            }
        }
    }

	void Start ()
    {
        //initialize DoTween
        DOTween.Init();

        //Initialize some other elements
        inputManager.OnPlayerMovePressed.AddListener(OnMovePlayerPressed);

        //Instantiate Player
        GameObject instantiatedPlayer = Instantiate(playerObject, Vector3.zero, Quaternion.identity);
        Utilities.GetIMapElement(instantiatedPlayer).SetPosition(new Vector2Int(4, 2));
        AddElementToMap(instantiatedPlayer);
        playerElement = Utilities.GetIMapElement(instantiatedPlayer);

        //Now some Obstacles at random positions
        for (int i = 0; i < 8; i++)
        {
            Vector2Int tryPosition = new Vector2Int(UnityEngine.Random.Range(0, mapWidth), UnityEngine.Random.Range(0, mapHeight));
            if (mapElements.ContainsKey(tryPosition))
                break;

            GameObject instantiatedObstacle = Instantiate(obstacleObject, Vector3.zero, Quaternion.identity);
            instantiatedObstacle.transform.position = (Vector2)tryPosition;
            AddElementToMap(instantiatedObstacle);
        }

        //Finally some enemiezzz
        enemyElements = new List<IMapElement>();
        for (int i = 0; i < 8; i++)
        {
            Vector2Int tryPosition = new Vector2Int(UnityEngine.Random.Range(0, mapWidth), UnityEngine.Random.Range(0, mapHeight));
            if (mapElements.ContainsKey(tryPosition))
                break;

            GameObject instantiatedEnemy = Instantiate(enemyObject, Vector3.zero, Quaternion.identity);
            Utilities.GetIMapElement(instantiatedEnemy).SetPosition(tryPosition);
            AddElementToMap(instantiatedEnemy);
            enemyElements.Add(Utilities.GetIMapElement(instantiatedEnemy));
        }

        //Some final Routines
        CurrentTurn = Turn.PLAYER;
    }	
	
	void Update ()
    {
        
	}

    private void AddElementToMap(GameObject mapElement)
    {
        mapElements.Add(Vector2Int.RoundToInt(mapElement.transform.position),
                        Utilities.GetIMapElement(mapElement));
    }

    private void OnMovePlayerPressed(Vector2Int direction)
    {
        if(MoveElementRoutine(playerElement, playerElement.GetPosition() + direction))
        {
            inputManager.gameObject.SetActive(false);
            CurrentTurn = Turn.ENEMY;
        }
    }
    private void RepositionInputs()
    {
        inputManager.transform.position = (Vector2)playerElement.GetPosition();
    }
    private bool MoveElementRoutine(IMapElement element, Vector2Int targetPosition)
    {
        if (mapElements.ContainsKey(targetPosition))
        {
            return false;
        }

        mapElements.Remove(element.GetPosition());
        element.Move(targetPosition);
        mapElements.Add(targetPosition, element);
        return true;
    }

    private void ProcessEnemyTurn()
    {
        CurrentTurn = Turn.PLAYER;

        for (int i = 0; i < enemyElements.Count; i++)
        {
            Vector2Int[] directions = new Vector2Int[] { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };
            for (int j = 0; j < 5; j++)
            {
                if(MoveElementRoutine(enemyElements[i], enemyElements[i].GetPosition() + directions[UnityEngine.Random.Range(0, 4)]))
                {
                    break;
                }
            }
        }
    }
}
