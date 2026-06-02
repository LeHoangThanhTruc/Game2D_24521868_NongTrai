using UnityEngine;
//MonoBehaviour là lớp cơ sở mà tất cả các script trong Unity đều kế thừa. Nó cung cấp các phương thức và thuộc tính cơ bản để tương tác với hệ thống của Unity.
//Không hẳn lúc nào cũng cần MonoBehaviour. Những thứ xuất hiện trên màn hình, di chuyển, tương tác bắt buộc phải có : MonoBehaviour để kéo thả vào Game Object.
//MonoBehaviour biến đoạn code thành một thành phần có thể kéo thả vào nhân vật và tự động chạy được trong game.
public class Chuot_DiChuyen_Player : MonoBehaviour
{
    public Rigidbody2D rb; 
    public float speed = 5f;
    private Vector2 movement; 
    public Animator animator;

    //Đối với chuột, dùng 1 biến để xác định vị trí hiện tại của chuột trong tró chơi
    private Vector2 mousePosition;

    private bool isMoving = false;

    void Update()
    {
        if(Input.GetMouseButtonDown(button: 0)) //0 là chuột trái, 1 là chuột phải
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Lấy vị trí của chuột trong thế giới trò chơi 
            isMoving = true;
        }
        movement = (mousePosition - rb.position).normalized; 
        animator.SetFloat(name: "ChieuNgang", movement.x);
        animator.SetFloat(name: "ChieuDoc", movement.y); 
        animator.SetFloat(name: "TocDo", isMoving? 1 : 0); 
    }
    private void FixedUpdate()
    {
        if (isMoving == true)
        {
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
            if (Vector2.Distance(rb.position, mousePosition) <= 0.1f)
            {
                isMoving = false;
                Debug.Log(message: "Toi noi roi");
            }
        }     
    }
}
