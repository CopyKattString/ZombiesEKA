using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Gamemanager : MonoBehaviour
{
    public GameObject selectedZombie;
    public GameObject[] zombies;
    public Vector3 selectedSize; 
    InputAction  left, right, jump;
    private int selectedindex = 0;
    public Vector3 pushForce;
    public TMP_Text timerText;
    private float time = 0;
    void Start()
    {
        SelectZombie(0);
        left = InputSystem.actions.FindAction("PrevZombie");
        right = InputSystem.actions.FindAction("NextZombie");
        jump = InputSystem.actions.FindAction("Jump");
    }

    void SelectZombie(int index)
    {
        if (selectedZombie != null)
            selectedZombie.transform.localScale = Vector3.one;
        selectedZombie = zombies[index];
        selectedZombie.transform.localScale = selectedSize;
        Debug.Log("selected" + selectedZombie.name);  
    }
    // Update is called once per frame
    void Update()
    {
        if (left.triggered)
        {
            selectedindex--;
            if (selectedindex < 0)
                selectedindex = zombies.Length - 1;
            SelectZombie(selectedindex);
        }
        if (right.triggered)
        {
            selectedindex++;
            if (selectedindex >= zombies.Length)
                selectedindex = 0;
            SelectZombie(selectedindex);
        }
        if(jump.WasPressedThisFrame())
        {
            Rigidbody rb = selectedZombie.GetComponent<Rigidbody>();
            rb.AddForce(pushForce);
        }
    }
}
