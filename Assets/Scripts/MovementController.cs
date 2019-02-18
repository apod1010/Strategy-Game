using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MovementController : MonoBehaviour
{

    public float speed = 1;

    Vector3 lookPosition;


    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);

        //rigidbody.AddForce(movement * speed / Time.deltaTime);
    }

    /// <summary>
    /// //////////////////
    /// </summary>

    float rotateSpeed = 10f;

    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        guiObject.SetActive(false);
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.destination = hit.point;
            }
        }




        if(Physics.Raycast(ray, out hit, 100))
        {
            lookPosition = hit.point;
        }

        Vector3 LookDirection = lookPosition - transform.position;
        LookDirection.y = 0;

        transform.LookAt(transform.position + LookDirection, Vector3.up);
    }


    public GameObject guiObject;
    public string levelToLoad;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Door")
        {
            guiObject.SetActive(true);
            if (guiObject.activeInHierarchy == true && Input.GetButtonDown("Use"))
            {
                SceneManager.LoadScene(levelToLoad);
            }
        }
    }
    private void OnTriggerExit()
    {
        guiObject.SetActive(false);
    }
}