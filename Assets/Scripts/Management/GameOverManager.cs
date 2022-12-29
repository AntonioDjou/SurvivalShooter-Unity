using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    Animator anim;
    
    public float restartDelay = 5f; // How long is going to take from the player dies until restarts the game.
    float restartTimer; // Counter for the delay.

    public Text coundownText; //Mostra o tempo disponível para o jogador.
    public int remainingTime = 3; //Tempo de jogo.


    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        StartCoroutine("LoseTime"); // Chama a rotina de contagem de tempo de jogo.
    }


    void Update()
    {
        coundownText.text = ("" + remainingTime); //Imprime o valor do tempo disponível.

        if (remainingTime == 0 || playerHealth.currentHealth <= 0) //Prepara a função de GameOver
        {
            StopCoroutine("LoseTime"); //Para a rotina de contagem do tempo.
            coundownText.text = "0"; //Imprime que o tempo disponível chegou ao zero.
            anim.SetTrigger("GameOver"); //Inicia a animação de Fim de Jogo.

            restartTimer += Time.deltaTime; //Faz o somatório do tempo em segundos que demorou para completar o último frame na variável "restartTimer" 
            if (restartTimer >= restartDelay) //Compara se o tempo da tela de GameOver já encerrou
            {
                SceneManager.LoadScene("Level1"); //Carrega a cena inicial do jogo.
            }
        }
    }

    IEnumerator LoseTime() //Inicia a rotina de contagem de tempo. A cada um segundo decrementa o tempo de jogo.
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            remainingTime--;
        }
    }   
}
