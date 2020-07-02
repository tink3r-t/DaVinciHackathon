public enum LANGUAGE {
    EN = 4,
    DE = 1
};


public class Preferences 
{

    public static int LanguageInt = (int) LANGUAGE.DE;

#if UNITY_EDITOR
    public static float TextSpeed  = 0.01f;
#else
    public static float TextSpeed  = 0.1f;
#endif

    public static float NotificationShowSpeed = 1.0f;
}
