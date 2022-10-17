using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Tags
{
    Ground,
    Fire,
    Enemy
}
public class Connector : MonoBehaviour
{
    public static Connector instance;
    [field: SerializeField] public InputControl IC { get; private set; }
    [field: SerializeField] public GestureInput ICgesture { get; private set; }
    [field: SerializeField] public PlayerMoveControl ICmove { get; private set; }
    [field: SerializeField] public Rigidbody2D rb2d { get; private set; }
    [field: SerializeField] public Animator animator { get; private set; }
    [field: SerializeField] public Animator FSM { get; private set; }
    [field: SerializeField] public AnimationController AniControl { get; private set; }
    [field: SerializeField] public StateController StateControl { get; private set; }
    [field: SerializeField] public GameObject Facing { get; private set; }
    [field: SerializeField] public PlayerMover Mover { get; private set; }
    [field: SerializeField] public OnGroundChecker GroundCheck { get; private set; }
    [field: SerializeField] public WallChecker WallCheck { get; private set; }
    [field: SerializeField] public PlayerAttackInterface PlayerAttack { get; private set; }
    [field: SerializeField] public AniEventHaldeler AniEvent { get; private set; }
    [field: SerializeField] public FireDetectorL FireInL { get; private set; }
    [field: SerializeField] public FireDetectorS FireInS { get; private set; }
    [field: SerializeField] public PlayerHealthSystem HealSystem { get; private set; }
    [field: SerializeField] public PlayerSoundInterface SoundL { get; private set; }
    [field: SerializeField] public PlayerSoundInterface SoundS { get; private set; }
    private void Awake()
    {
        if (Connector.instance == null) Connector.instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
