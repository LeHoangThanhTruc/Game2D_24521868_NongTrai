using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerDiChuyen : MonoBehaviour
{
    public Rigidbody2D rb; //tham chiếu đến thành phần Rigidbody2D của nhân vật
    public float speed = 5f; //tốc độ di chuyển của nhân vật
    private Vector2 movement; //Hướng để con nhân vật di chuyển 
    public Animator animator; //Tham chiếu đến thành phần Animator của nhân vật để điều khiển hoạt ảnh

    //Hàm Start() được gọi trước khi lần đầu tiên Update() được gọi, ngay khi game được tạo
    void Start()
    {
        /*// Tự động tìm Rigidbody2D trên cùng đối tượng này
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();

        // Tự động tìm Animator trên cùng đối tượng này
        if (animator == null)
            animator = GetComponent<Animator>();*/
    }
    //Hàm Update() được gọi một lần mỗi khung hình, và nó là nơi nên đặt mã để kiểm tra đầu vào của người chơi và cập nhật trạng thái của trò chơi.
    void Update()
    {
        //Lấy đầu vào từ người chơi để xác định hướng di chuyển của nhân vật
        movement.x = Input.GetAxisRaw(axisName: "Horizontal"); //Lấy giá trị trục ngang (trái/phải) từ người chơi và gán nó cho thành phần x của vector movement. Giá trị này sẽ là -1, 0 hoặc 1 tùy thuộc vào việc người chơi nhấn phím nào (ví dụ: A/D hoặc phím mũi tên trái/phải).
        movement.y = Input.GetAxisRaw(axisName: "Vertical"); //Lấy giá trị trục dọc (lên/xuống) từ người chơi và gán nó cho thành phần y của vector movement. Giá trị này cũng sẽ là -1, 0 hoặc 1 tùy thuộc vào việc người chơi nhấn phím nào (ví dụ: W/S hoặc phím mũi tên lên/xuống).
        animator.SetFloat(name:"ChieuNgang", movement.x);
        animator.SetFloat(name: "ChieuDoc", movement.y); //Gán giá trị của thành phần x và y của vector movement cho các tham số "ChieuNgang" và "ChieuDoc" trong Animator. Điều này giúp điều khiển hoạt ảnh dựa trên hướng di chuyển của nhân vật.
        animator.SetFloat(name: "TocDo", movement.sqrMagnitude); //Tính toán tốc độ di chuyển bằng cách sử dụng bình phương của độ dài của vector movement (movement.sqrMagnitude) và gán nó cho tham số "TocDo" trong Animator. Điều này giúp điều khiển hoạt ảnh dựa trên tốc độ di chuyển của nhân vật.
    }
    //Hàm FixedUpdate() được gọi ở một tần số cố định, thường là 50 lần mỗi giây, và nó là nơi nên đặt mã để xử lý vật lý và di chuyển của nhân vật.
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime); //Di chuyển nhân vật bằng cách sử dụng phương thức MovePosition của Rigidbody2D. Phương thức này sẽ di chuyển nhân vật đến vị trí mới được tính toán bằng cách cộng vector movement (hướng di chuyển) với tốc độ (speed) và thời gian giữa các lần gọi FixedUpdate (Time.fixedDeltaTime). Điều này đảm bảo rằng nhân vật di chuyển mượt mà và không bị ảnh hưởng bởi tốc độ khung hình của trò chơi.
    }
}

