using System.Collections.Generic;
using UnityEngine;

//  Class responsible of object placement in the scene with respect to 
//  the initial position given by the user tap
public class Positions { 
    // User gaze coordinates after the Spatial processing scan
    Vector3 gazePosition;

    // Used to calculate the offset positions of the objects from the gazePosition
    Transform gazeTransform = new GameObject("HitPoint").transform;
    Transform gameTable = new GameObject("Kids room").transform;
    public Vector3 tablePosition;
    public Transform nearestTable = null;

    //  Floor coordinates
    //public Vector3 floorPosition;

    //  Table coordinates
    //public Vector3 tablePosition;

    public static readonly float FrontDistance = -0.9f;

    public static readonly Vector3 Central = new Vector3(0, 0.1f, FrontDistance + 1.2f);
    public static readonly Vector3 AsideLeft = new Vector3(-0.2f, 0.1f, FrontDistance + 1);
    public static readonly Vector3 AsideRight = new Vector3(0.2f, 0.1f, FrontDistance + 1);

    //  Scene 2
    public static readonly Vector3 ArkPosition = new Vector3(0.018f, 0.1f, 0.6f);
    public static readonly Vector3 startPositionInlineThree = new Vector3(-0.1f, 0.1f, 0.1f);

    //Scene 3
    public static readonly Vector3 TreePosition = new Vector3(0, 0.1f, FrontDistance + 1.6f);
    public static readonly Vector3 HousePosition = new Vector3(-0.7f, 0.075f, FrontDistance + 1.7f);
    public static readonly Vector3 Character1Position = new Vector3(-0.375f, 0.1f, FrontDistance + 1.1f);
    public static readonly Vector3 Character1Basket = new Vector3(-0.375f, 0.1f, FrontDistance + 0.95f);
    public static readonly Vector3 Character2Position = new Vector3(0.375f, 0.1f, FrontDistance + 1.1f);
    public static readonly Vector3 Character2Basket = new Vector3(0.375f, 0.1f, FrontDistance + 0.9f);
    public static readonly Vector3 VAPosition = new Vector3(-0.4f, 0.1f, FrontDistance + 0.7f);

    //  Default position for non active objects
    public static readonly Vector3 hiddenPosition = new Vector3(0, 0.1f, FrontDistance - 3);

    //  Start position for spawning 4 objects aligned in scene1
    public static readonly Vector3 startPositionInlineFour = new Vector3(-0.3f, 0.815f, FrontDistance + 2.25f);
    public static readonly Vector3 CentralNear = new Vector3(0, 0.1f, FrontDistance + 1);

    //Rotation to make the objects be oriented towards the user
    public static Quaternion ObjectsRotation = new Quaternion();
    //private float height;
    private float height = 0.815f;
    public Vector3 VAPositionOnTable;

    public DeskGrid Grid { get; private set; }
    public Transform TableTransform { get; set; }
    public bool UseTable { get; private set; }

    public Vector3 GetVaPositionOnTable() {
        Vector3 VaPosition = VAPositionOnTable;
        VaPosition.y = height;
        return VaPosition;
    }

    //  Compute the object position with respect to the gazePosition and the floorPosition
    public Vector3 GetPosition(Vector3 position) {
     
        position = gazeTransform.TransformPoint(position);

        return position;
    }

    public void OrientObjects() {

        gazePosition = new Vector3(0f, 0f, 0f);
        gazeTransform.position = gazePosition;

        Vector3 relativePos = Camera.main.transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);

        rotation.x = 0f;
        rotation.y = 0f;
        rotation.z = 0f;

        gazeTransform.rotation = rotation;
        rotation.x = 90f;
        rotation.z = 0f;
        ObjectsRotation = rotation;
    }

    public void FindTable() {
        UseTable = true;
        gameTable = GameObject.Find("Kids Desk").transform;
        gazePosition = new Vector3(0f, 0, 0f);
        
        gazeTransform.position = gazePosition;

        Vector3 relativePos = Camera.main.transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);


        rotation.x = 0f;
        rotation.y = 0f;
        rotation.z = 0f;

        gazeTransform.rotation = rotation;
        rotation.x = 90f;
        rotation.z = 0f;
        ObjectsRotation = rotation;
        SimpleGridGenerator gridGenerator = new SimpleGridGenerator(gameTable, height);
        Grid = gridGenerator.Grid;
        VAPositionOnTable = gridGenerator.GetVAPosition();
    }
    
    private Bounds GetColliderBounds() {
        return nearestTable.GetComponent<Collider>().bounds;
    }

}