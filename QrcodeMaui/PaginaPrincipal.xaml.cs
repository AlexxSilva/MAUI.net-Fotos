using Camera.MAUI;

namespace TakeFoto;

public partial class PaginaPrincipal : ContentPage
{
    public PaginaPrincipal()
    {
        InitializeComponent();
    }


    private async void Tirarfoto(object sender, EventArgs e)
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

            if (photo != null)
            {
                // save the file into local storage
                string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                using Stream sourceStream = await photo.OpenReadAsync();
                using FileStream localFileStream = File.OpenWrite(localFilePath);

                await sourceStream.CopyToAsync(localFileStream);
            }
        }
    }

    private void cameraView_CamerasLoaded(object sender, EventArgs e)
    {
        if (cameraView.NumCamerasDetected > 0)
        {
            if (cameraView.NumMicrophonesDetected > 0)
                cameraView.Microphone = cameraView.Microphones.First();
            cameraView.Camera = cameraView.Cameras.First();
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await cameraView.StopCameraAsync();
                await cameraView.StartCameraAsync();
                //if (await cameraView.StartCameraAsync() == CameraResult.Success)
                //{
                //    controlButton.Text = "Stop";
                //    playing = true;
                //}
            });
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        mySmage.Source = cameraView.GetSnapShot(Camera.MAUI.ImageFormat.PNG);
    }
}