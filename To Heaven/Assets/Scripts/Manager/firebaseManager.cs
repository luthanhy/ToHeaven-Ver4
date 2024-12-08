using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System.Threading.Tasks;
public class firebaseManager : MonoBehaviour
{
    private DatabaseReference reference;
    private void Awake(){
        FirebaseApp app = FirebaseApp.DefaultInstance;
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }
    private void Start(){
        WriteDatabases("test","test");
        ReadDatabases("test");
    }
    public void ReadDatabases(string id){
        reference.Child("User").Child(id).GetValueAsync().ContinueWithOnMainThread(task=>{
            if(task.IsCompleted){
                DataSnapshot snapshot = task.Result;
                Debug.Log("data" + snapshot.Value.ToString());
            }
        });
    }
    public void WriteDatabases(string id , string message){
        reference.Child("User").Child(id).SetValueAsync(message).ContinueWithOnMainThread(task => {
            if(task.IsCompleted){
                Debug.Log("Write Success");
            }else{
                Debug.Log("Write Failed " + task.Exception );
            }
        });
    }
}
