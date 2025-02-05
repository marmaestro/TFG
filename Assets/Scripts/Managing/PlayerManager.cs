using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static void Move(Vector2 direction)
    {
        // TODO : MOVE CHARACTER AROUND
    }

    public static void Interact()
    {
        // TODO : INTERACT WITH SURROUNDING STUFF
        if (!CameraWorks.CameraIsOpen) return;
        else CameraWorks.SavePicture();
    }

    public static void Cancel()
    {
        // TODO : CANCEL ACTION / CLOSE
        if (!CameraWorks.CameraIsOpen) return;
        else if (CameraWorks.PictureIsShown) CameraWorks.DiscardPicture();
        else CameraWorks.CloseCamera();
    }

    public static void TakePicture()
    {
        if (!CameraWorks.CameraIsOpen) CameraWorks.OpenCamera();
        else CameraWorks.TakePicture();
    }
}