
using UnityEngine;
using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Unity;
using BeardedManStudios.Forge.Networking.Generated;

using UnityEngine.SceneManagement;

public class refresh : MonoBehaviour
{

   
    [SerializeField] private UnityEngine.UI.InputField portNumber;
    [SerializeField] private Mover parent;
    public void GetBack(){
        NetworkManager.Instance.Disconnect();

        var networkObject = ((CubeCustomMoveBehavior)parent).networkObject;
        if (networkObject != null)
			networkObject.Destroy();

        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    public void Refresh()
    {
        NetWorker.RefreshLocalUdpListings(ushort.Parse(portNumber.text));
    }
}
