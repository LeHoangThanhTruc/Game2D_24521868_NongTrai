using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using UnityEditor.VersionControl;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class FirebaseDatabaseManager : MonoBehaviour
{
    private DatabaseReference reference;
    //Hàm Awake() chạy trước cả khi màn hình lên
    private void Awake()
    { 
        FirebaseApp app = FirebaseApp.DefaultInstance;
        reference = FirebaseDatabase.DefaultInstance.RootReference;  //Tự động lấy được đường dẫn trong file json ở  thư mục Asset
    }
    private void Start()
    {
        TilemapDetail tilemapDetail = new TilemapDetail(x: 1, y: 1, tilemapState: TilemapState.Ground);
        //Ghi dữ liệu vào Firebase Realtime Database
        WriteDatabase(id: "User1", tilemapDetail.ToString());
        //Đọc dữ liệu từ Firebase Realtime Database
        ReadDatabase(id: "User1");
    }
    //Hàm ghi dữ liệu vào Firebase Realtime Database
    public void WriteDatabase(string id,string message)
    {
          reference.Child(pathString: "User").Child(id).SetValueAsync(message).ContinueWithOnMainThread(task =>
          {
              if (task.IsCompleted)
              {
                  Debug.Log(message: "Ghi du lieu thanh cong");
              }
              else
              {
                  Debug.LogError("Ghi du lieu that bai: " + task.Exception);
              }
          });
    }
    //Hàm đọc dữ liệu từ Firebase Realtime Database
    public void ReadDatabase(string id)
    {
        reference.Child(pathString: "User").Child(id).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                string message = snapshot.Value.ToString();
                Debug.Log("Doc du lieu thanh cong: " + message);
            }
            else
            {
                Debug.LogError("Doc du lieu that bai: " + task.Exception);
            }
        });
    }
}
