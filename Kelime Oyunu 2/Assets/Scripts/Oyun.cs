using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Oyun : MonoBehaviour
{

    // Start is called before the first frame update
    public List<Slotlar> gelensorular;
   
    [HideInInspector]
    public Slotlar suankiSoru = new Slotlar();

    // son yazdıgımı unut ortada nesne yok daha mantıklı oldu 
    public GameObject soruObje;
    public GameObject cevapObje;
    public GameObject tahminText;
    public GameObject ata;
    public GameObject puanText;
    public Text timeText;
    public string[] gelen;
    public int puan ;
    public int tıklama;
    void Start()
    {

        SoruVer();
    }
    void Awake()
    {
        veritabanı vt = new veritabanı();
        gelensorular = vt.dataReader();
    }
   public void SoruVer()
    {// evlatları oldurur asfsafsafsdasfda soruları da öldğrmemiz lazım kullandığımız niye aynı soru mu gelyor evet görmedin dogru o iş kolay
        foreach (Transform child in ata.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        int RandomSoru = Random.Range(0, gelensorular.Count);
        suankiSoru = gelensorular[RandomSoru];
        gelensorular.RemoveAt(RandomSoru);// bitti biymemis kaydetmemişes sen kaç istersen soru bittigi için boş geldi  anladım onu zor kısımlar kaldı sana kolay ları adasdsa zor ne kaldı ki olum tahmin et var bi o nu da yapak onu yapıp bırakam 
        string soru = suankiSoru.soru;

        //gelen sorudaki harflerin indisleri attıgımız dizi  
        gelen = new string[suankiSoru.cevap.Length];//hata verecek hissediyorum adsadasdannull ile karşılaştırma yapılamaz gibi birşey diyecek bir deniyek sonra burda doldururuz 
        // diziyi her soru için cevap uzunlugunda oluşturduk 
        soruObje.GetComponent<Text>().text = suankiSoru.soru;
        for (int i = 0; i < suankiSoru.cevap.Length; i++)
        {
            GameObject Slotlar = Instantiate(cevapObje, transform);
            Slotlar.GetComponentInChildren<Text>().text = suankiSoru.cevap[i].ToString();
            Slotlar.GetComponentInChildren<Text>().enabled = false;
        }

        if(gelensorular.Count == 0)
        {
            SceneManager.LoadScene(3);
        }
        /*burdan hangisi acilacagini kontrol edebiliyorsun artık bunu başla bir fonksiyonda harf al şeklinde yapalım mantıklı
      
        /*   bu kısım cevaplar içindi slotları artırıp cevabın kelime sayısına göre yapıyor yani hardtextleri falan çağırdım ama cevap gelmedi daha oke     */
    }
    public void TahminEt()
    {
        if(tahminText.GetComponent<Text>().text.ToLower() == suankiSoru.cevap.ToLower())
        {
           
            puan += (suankiSoru.cevap.Length*100) - (tıklama*100);
            puanText.GetComponent<Text>().text = puan.ToString();
            SoruVer();

            tıklama = 0;
        }
        else
        {
            puan -= (suankiSoru.cevap.Length * 100) + (tıklama * 100);
            puanText.GetComponent<Text>().text = puan.ToString();
            SoruVer();
            tıklama = 0;
        }

    }
 
    public void HarfAl()
    {
        int RandomSoru = Random.Range(0, suankiSoru.cevap.Length);//harfin ransegel gelme aralıgı böyle olmaz mı burasıl dogru bu şekilde aynı harf tekrar tekrar gelir 
        
        int gecerliObje = -1;
        tıklama++;
      
        while (gelen[RandomSoru] == RandomSoru.ToString())
        {
          //  RandomSoru = Random.Range(0, suankiSoru.cevap.Length);
            int Sorurand = Random.Range(0, suankiSoru.cevap.Length);
            // bir öncekinin aynı gelmeyene kadar 
            if(gelen[Sorurand] != Sorurand.ToString() && gelen[Sorurand] == null)
            {
             ata.transform.GetChild(Sorurand).GetComponentInChildren<Text>().enabled = true;
                gelen[Sorurand] = Sorurand.ToString();
                gecerliObje = Sorurand;
                break; 
            }
        
        }//eşit olmaya bilir ama bu durumda da gelenlerden biri ile hem kendisi olmayacak hemde içi boş olacak ki yeni gelsin 
      


        if( gelen[RandomSoru] != RandomSoru.ToString() && gelen[RandomSoru]==null)
            {
                ata.transform.GetChild(RandomSoru).GetComponentInChildren<Text>().enabled = true;
             gecerliObje = RandomSoru;
               gelen[RandomSoru] = RandomSoru.ToString();
            
            }
        ata.transform.GetChild(gecerliObje).GetComponentInChildren<Animation>().enabled = true;
        
       
       
       
    }
    



}
