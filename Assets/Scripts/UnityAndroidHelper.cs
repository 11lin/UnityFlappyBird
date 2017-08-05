using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Android相关操作
/// </summary>
public class UnityAndroidHelper:MonoBehaviour
{
#if UNITY_ANDROID
    void OnStart()
    {
        UnityAndroidHelper.callJava();
        UnityAndroidHelper.javaCall();
    }
    /// <summary>
    ///UnityEngine.AndroidJavaObject和UnityEngine.AndroidJavaClass
    ///映射到java.lang.Object中和java.lang.Class
    ///注意：Java嵌套类不能使用using表示类实例化。
    ///内部类必须使用$separator。
    ///使用android.view.ViewGroup$LayoutParams或android/view/ViewGroup$LayoutParams，
    ///其中LayoutParams类嵌套在ViewGroup类中。
    /// </summary>
    public static void callJava()
    {
        AndroidJavaObject jo = new AndroidJavaObject("java.lang.String", "some_string");
        // jni.FindClass("java.lang.String"); 
        // jni.GetMethodID(classID, "<init>", "(Ljava/lang/String;)V"); 
        // jni.NewStringUTF("some_string"); 
        // jni.NewObject(classID, methodID, javaString); 
        int hash = jo.Call<int>("hashCode");
        Debug.Log("Unity Log:" + hash.ToString());
        // jni.GetMethodID(classID, "hashCode", "()I"); 
        // jni.CallIntMethod(objectID, methodID);  


        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        // jni.FindClass("com.unity3d.player.UnityPlayer"); 
       
        AndroidJavaObject jo2 = jc.GetStatic<AndroidJavaObject > ("currentActivity");
        // jni.GetStaticFieldID(classID, "Ljava/lang/Object;"); 
        // jni.GetStaticObjectField(classID, fieldID); 
        // jni.FindClass("java.lang.Object"); 

        Debug.Log(jo2.Call<AndroidJavaObject> ("getCacheDir").Call<string>("getCanonicalPath"));
        // jni.GetMethodID(classID, "getCacheDir", "()Ljava/io/File;"); // or any baseclass thereof! 
        // jni.CallObjectMethod(objectID, methodID); 
        // jni.FindClass("java.io.File"); 
        // jni.GetMethodID(classID, "getCanonicalPath", "()Ljava/lang/String;"); 
        // jni.CallObjectMethod(objectID, methodID); 
        // jni.GetStringUTFChars(javaString);              
    }
    /// <summary>
    /// Java调用Unity
    /// </summary>
    public static void javaCall()
    {
        //如果设置AndroidJNIHelper.debug为true，您将在调试输出中看到垃圾回收器的活动记录。
        AndroidJNIHelper.debug = true;
        //using声明，以确保他们尽快删除。
        using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            jc.CallStatic("UnitySendMessage", "UnityAndroidHelper", "javaMessage", "From Java Message");
        }
    }
    void javaMessage(string msg)
    {
        Debug.Log("Unity Log From Java:" + msg);
    }
#endif
}
