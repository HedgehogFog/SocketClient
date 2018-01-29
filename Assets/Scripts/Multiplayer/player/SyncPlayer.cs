namespace Multiplayer.player
{
    public class SyncPlayer
    {
        public void SendPos(float x, float y, float z)
        {
            TcpController.instance.Send("action:move;x:" + x + ";y:" + y + ";z:" + z + ";");
        }
    }
}