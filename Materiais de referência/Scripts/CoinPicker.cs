using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Bibliotecas
public class CoinPicker : MonoBehaviour { // Nome da Classe

    

    private int coin; //Conta o numero de moedas
    public Text scoreText; //Pontuação
     public Text lifeText; // Vida
    private int life = 10; // barra de vida
    public Image healthbar; // Imagem da barra de vida

    public AudioSource coinSound; // Som de pegar a  Moeda
    public AudioSource lifeSound; // Som da morte

    public AudioSource faseSound; // Som da Mudança de fase
    
    
    private void Start()
    {
        //inicializa variaveis 
        coin = ScriptController.userPoints;
        scoreText.text = "";
        lifeText.text = "";
        life = ScriptController.userLife;
        
      
    }

    private void Update()
    {
        scoreText.text = "Coins: "+coin.ToString();
        lifeText.text = "Life: "+life.ToString();
        UpdateHealthBar();
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Itens") == true) //Essa condição verifica se o player encostou com um objeto com rotulo Coin
          {
              coinSound.Play(); //som de pegar moeda
              //GetComponent<AudioSource>().Play();  
              coin += 1; // Incrementa contador
              Destroy(collision.gameObject); //Peguei a moeda destroi a moeda
              ScriptController.userPoints=coin;
          }
          if(collision.CompareTag("Inimigo") == true)//Essa condição verifica se o player encostou com um objeto com rotulo Fire
          {
              lifeSound.Play(); //Som de dor
              //GetComponent<AudioSource>().Play();  
              life -= 1; //Decrementa a vida
              Destroy(collision.gameObject); //Destroi o fogo
              ScriptController.userLife=life;
              ScriptController.carregaHistoria();
          }
          if(collision.CompareTag("Fase") == true)
          {
             faseSound.Play();
              //SceneManager.LoadScene("fase2");
              //ScriptController.userPoints=coin;
              //ScriptController.userLife=life;
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
              
          }
    }
    private void UpdateHealthBar()
    {
        healthbar.fillAmount = life/10;
    }
    


}