using Firebase.Auth;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Extensions;
using UnityEngine.SceneManagement;
public class FirebaseLoginManager : MonoBehaviour 
{
    //Đăng ký
    [Header(header: "Register")]
    public InputField ipRegisterEmail;
    public InputField ipRegisterPassword;
    public Button buttonRegister;
    //Đăng nhập
    [Header(header: "Sign In")]
    public InputField ipLoginEmail;
    public InputField ipLoginPassword;
    public Button buttonLogin;

    private FirebaseAuth auth;
    // Chuyển đổi qua lại giữa đăng ký và đăng nhập
    [Header(header: "Switch form")]
    public Button buttonMoveToLogin;
    public Button buttonMoveToRegister;
    public GameObject loginForm;
    public GameObject registerForm;

    private void Start() 
    {
        auth = FirebaseAuth.DefaultInstance;
        buttonRegister.onClick.AddListener(RegisterAccountWithFirebase);
        buttonLogin.onClick.AddListener(SignInAccountWithFirebase);
        buttonMoveToRegister.onClick.AddListener(SwitchForm);
        buttonMoveToLogin.onClick.AddListener(SwitchForm);
    }
    public void RegisterAccountWithFirebase()
    {
        string email = ipRegisterEmail.text;
        string password = ipRegisterPassword.text;
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task => 
        {
            if (task.IsCanceled) 
            {
                Debug.Log(message: "Dang ky bi huy");
                return;
            }
            if (task.IsFaulted) 
            {
                Debug.LogError(message: "Dang ky that bai");
            }
            if(task.IsCompleted) 
            {
                Debug.Log(message: "Dang ky thanh cong");
            }
            
        });
    }
    public void SignInAccountWithFirebase()
    {
        string email = ipLoginEmail.text;
        string password = ipLoginPassword.text;
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task => 
        {
            if (task.IsCanceled) 
            {
                Debug.Log(message: "Dang nhap bi huy");
                return;
            }
            if (task.IsFaulted) 
            {
                Debug.LogError(message: "Dang nhap that bai");       
            }
            if(task.IsCompleted) 
            {
                Debug.Log(message: "Dang nhap thanh cong");
                FirebaseUser user = task.Result.User;
                //Chuyển scence
                SceneManager.LoadScene(sceneName: "SampleScene");
            }
            
        });
    }
    public void SwitchForm()
    {
        loginForm.SetActive(!loginForm.activeSelf);
        registerForm.SetActive(!registerForm.activeSelf);
    }
}
