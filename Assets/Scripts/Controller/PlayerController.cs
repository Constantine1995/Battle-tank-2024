using UnityEngine;
public class PlayerController : MonoBehaviour{
   
     GameController gameController;

    float speedMoving = 7.0f;
    float speedRotation = 100f;
    Vector2 movementVector = Vector2.zero;
    //private PlayerModel Model { get; set; }
    //private PlayerView View { get; set; }
    //public PlayerController(PlayerModel model, PlayerView view)
    //{
    //    Model = model;
    //    View = view;

    //}
    //public void Update()
    //{
    //    if (View.EnemyController != null)
    //    {
    //        Model.GetDamage(View.EnemyController.GetDamage());

    //    }

    //    if (Model.isValueHpChanged)
    //    {
    //        View.SetHpNormalized(Model.BaseHp);
    //    }
    //}
    //public void LateUpdate()
    //{
    //    Model.LateUpdate();
    //    View.DoLateUpdate();
    //}

    private void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");
    }
    void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    void FixedUpdate()
    {
        Move(movementVector);
    }

    void Move(Vector2 movement)
    {
       transform.position += this.transform.up * speedMoving * movement.y * Time.deltaTime;
       transform.Rotate(Vector3.forward * speedRotation * -movement.x * Time.deltaTime);
    }
}
