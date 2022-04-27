using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static InputHandler instance;
    public List<Command> oldCommands = new List<Command>();

    public Transform boxTransform;
    private Command commandW, commandA, commandS, commandD, commandZ,commandR;
    private Vector3 boxStartPosition;
    private Coroutine replayCoroutine;
    private bool isReplaying = true;

    public bool startReplay = false;
    

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        commandW = new MoveForward();
        commandS = new MoveBackward();
        commandA = new MoveLeft();
        commandD = new MoveRight();
        commandZ = new UndoMove();
        commandR = new ReplayMove();
        boxStartPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (isReplaying)
        {
            HandleInput();
        }

        StartReplay();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
            commandW.Execute(boxTransform, commandW);
        if (Input.GetKeyDown(KeyCode.S))
            commandS.Execute(boxTransform, commandS);
        if (Input.GetKeyDown(KeyCode.A))
            commandA.Execute(boxTransform, commandA);
        if (Input.GetKeyDown(KeyCode.D))
            commandD.Execute(boxTransform, commandD);
        if (Input.GetKeyDown(KeyCode.Z))
            commandZ.Execute(boxTransform, commandZ);
        if (Input.GetKeyDown(KeyCode.R))
            commandR.Execute(boxTransform, commandR);
    }

    void StartReplay()
    {
        if(startReplay && oldCommands.Count > 0 )
        {
            startReplay = false;
            
            if(replayCoroutine != null)
            {
                StopCoroutine(replayCoroutine);
            }

            replayCoroutine = StartCoroutine(ReplayStarted(boxTransform));
        }
    }

    IEnumerator ReplayStarted(Transform transform)
    {
        isReplaying = true;

        transform.position = boxStartPosition;

        for (int i = 0; i < oldCommands.Count; i++)
        {
            oldCommands[i].Move(transform);

            yield return new WaitForSeconds(0.3f);
        }

        isReplaying = false;
    }
}
