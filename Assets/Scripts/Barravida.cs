using UnityEngine;
using UnityEngine.UI;

public class Barravida : MonoBehaviour
{
    public Image rellenoBarraVida;
    private PlayerMovement playerController;
    private float vidamaxima;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerMovement>();
        vidamaxima = playerController.vida;
    }

    // Update is called once per frame
    void Update()
    {
        rellenoBarraVida.fillAmount = playerController.vida / vidamaxima;
    }
}
