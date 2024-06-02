using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace client
{
    public class birdviewclient : MonoBehaviour
    {
        private string serverIP = "127.0.0.1";
        private int serverPort = 1234;

        private TcpClient client;
        private NetworkStream stream;
        private bool isConnected = false;
        public bool isRunning = true;

        public Transform[] objectsToUpdate; // References to the GameObjects' transforms to update

        async void Start()
        {
            await ConnectToServerAsync();
        }

        async Task ConnectToServerAsync()
        {
            try
            {
                client = new TcpClient(serverIP, serverPort);
                stream = client.GetStream();
                isConnected = true;
                bool startcars = false; 

                while (isRunning)
                {
                    byte[] buffer = new byte[2048];
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                    string[] positionData = dataReceived.Split('|');
                    //if (positionData.Length > 0)
                    //{
                    //    startcars = positionData[0] == "0";
                    //    Debug.Log("startcars value changed: " + startcars);
                    //}
                    for (int i = 0; i < Mathf.Min(positionData.Length, objectsToUpdate.Length); i++)
                    {
                        string[] positionComponents = positionData[i].Split(',');
                        if (positionComponents.Length == 3)
                        {
                            float posX = float.Parse(positionComponents[0]);
                            float posY = float.Parse(positionComponents[1]);
                            float posZ = float.Parse(positionComponents[2]);
                            objectsToUpdate[i].position = new Vector3(posX, posY, posZ);
                            if (objectsToUpdate[i].name == "TrailerRig")
                            {
                                Vector3 updatedPosition = objectsToUpdate[i].position;
                                updatedPosition.y += 1.21f;
                                objectsToUpdate[i].position = updatedPosition;
                            }
                        }

                    }
                }
            }
            catch (SocketException)
            {
            }
        }

        void OnDestroy()
        {
            isRunning = false;
            if (client != null)
                client.Close();
        }
    }
}