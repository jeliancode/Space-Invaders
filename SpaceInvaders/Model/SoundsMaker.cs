using Windows.Media.Core;
using Windows.Media.Playback;

namespace SpaceInvaders.Model;
public class SoundsMaker
{
    private MediaPlayer mediaPlayer;

    public void MakeSound(Uri uri)
    {
        mediaPlayer = new MediaPlayer();
        mediaPlayer.Source = MediaSource.CreateFromUri(uri);
        mediaPlayer.Play();
    }
}
