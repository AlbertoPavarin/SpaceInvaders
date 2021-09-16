using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Media;
/*Autore: Pavarin Alberto
 * Questo programma permette di giocare a space invaders
 */
namespace Space_Invaders
{
    public partial class Form1 : Form
    {
        bool destra, sinistra;
        int velocitaPlayer = 20;
        int velocitàNemici = 10;
        int punteggio = 0;
        int timerProiettiliNemici = 300;

        PictureBox[] Invaders;

        DataTable table = new DataTable(); 

        bool sparo;
        bool isgameOver;

        SoundPlayer esplosione = new SoundPlayer("suoni/EsplosionInavder.wav");
        SoundPlayer sparoSuono = new SoundPlayer("suoni/Sparo.wav");

        public Form1()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.Space_Invaders_intro;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.Space_Invaders_Gioco;
            nuovaPartitaBtn.Visible = false;
            RegoleBtn.Visible = false;
            playerPb.BackgroundImage = Properties.Resources.player;
            viteLbl.Visible = true;
            PunteggioTxt.Visible = true;
            RegoleBtn.Enabled = false;
            setup();
        }

        private void RegoleBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Le regole del gioco sono:\n1) Lo scopo del gioco è di distruggere gli invaders senza che loro ti distruggano o ti sorpassino.\n2) Per muoversi a destra bisogna premere il tasto 'freccia destra' e per muoversi a sinistra il tasto 'freccia sinistra'.\n3) Per sparare ai nemici bisogna premere la freccia in su.");
        }

        private void nuovaPartitaBtn_MouseHover(object sender, EventArgs e)
        {
            nuovaPartitaBtn.Cursor = Cursors.Hand; //Quando il cursore del mouse è sopra il bottone il cursore cambierà forma prendendo quella di una mano
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left) // Se il tasto premuto è uguale al tasto A allora la variabile booleana sinistra verrà inizializzata a true
            {
                sinistra = true;               
            }
            if (e.KeyCode == Keys.Right) // Se il tasto premuto è uguale al tasto D allora la variabile booleana destra verrà inizializzata a true
            {
                destra = true;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) // Se la freccia sinistra non è premuto allora la variabile booleana sinistra sarà inizializzata a false
            {
                sinistra = false;
            }
            if (e.KeyCode == Keys.Right) // Se la freccia destra non è premuto allora la variabile booleana destra sarà inizializzata a false
            {
                destra = false;
            }
            if (e.KeyCode == Keys.Up && sparo == false) // Se il tasto premuto è la freccia in su la variabile booleana sparo verrà inizializzata a true e verrà creato il proiettile tramite la funzione apposita
            {
                sparo = true;
                creazioneProiettili("proiettile");
            }
            if (e.KeyCode == Keys.Enter && isgameOver == true)
            {
                elimina();
                setup();
            }
        }

        private void creazioneInvaders()
        {
            Invaders = new PictureBox[25]; // Viene creata un array di PicturBox in modo da "ospitare" gli inavders
            int left = 0;

            for (int i = 0; i < Invaders.Length; i++)
            {
                Invaders[i] = new PictureBox();
                Invaders[i].Size = new Size(50, 50); // Viene inizializzata la grandezza di ogni Picturbox a 60 e 50
                Invaders[i].Image = Properties.Resources.invader1; // Viene assegnata l'immagine dell'invaders a ogni PictureBox
                Invaders[i].Top = 5; // Viene impostata a 5 la distanza dal bordo superiore   
                Invaders[i].Tag = "Invaders";
                Invaders[i].Left = left; // Viene impostata a left 
                Invaders[i].SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(Invaders[i]);
                left = left - 80; 
            }
        }

        private void RegoleBtn_MouseHover(object sender, EventArgs e)
        {
            RegoleBtn.Cursor = Cursors.Hand; // Quando il cursore è sopra il bottone il cursore assumerà la forma di un mano
        }

        private void mainGameTimer(object sender, EventArgs e)
        {
            PunteggioTxt.Text = "Punteggio: " + punteggio; // Viene scritto nella TextBox PunteggioTxt Il punteggio 

            if (sinistra) // Se sistra è uguale a true il player verrà spostato a sinistra di quanto è il valore di velocità player 
            {
                playerPb.Left -= velocitaPlayer;
            }

            if (destra) // Se sistra è uguale a true il player verrà spostato a sinistra di quanto è il valore di velocità player
            {
                playerPb.Left += velocitaPlayer;
            }

            if (playerPb.Left > 750 || playerPb.Left < 10) // Se il player va oltre il form viene riportato nella posizione iniziale
            {
                playerPb.Left = 370;
            }

            timerProiettiliNemici -= 10;

            if (timerProiettiliNemici < 1) // Se il timer dei proiettili è minore di 1 allora il timer viene risettato a 300 e viene creato il proiettile
            {
                timerProiettiliNemici = 300;
                creazioneProiettili("proiettileInvader");
                sparoSuono.Play();
            }

            foreach (Control x in this.Controls) // Per ogni x 
            {
                if (x is PictureBox && (string)x.Tag == "Invaders") // Se la x è una PicturBox e il tag è Invaders e quindi se la x è un nemico
                {
                    x.Left += velocitàNemici; // Viene spostato il nemico
                    if (x.Left > 730) // Se la distanza dal bordo sinistro è maggiore di 730 gli invaders saranno portati all'inizio e spostati verso il basso
                    {
                        x.Top += 65;
                        x.Left = -80;
                    }

                    if (x.Top > playerPb.Top) // Se gli invaders si trovano al di sotto del giocatore allora sarà mostrato il messaggio di gameover
                    {
                        gameOver("Gli invaders ti hanno superato, il mondo verrà conquistato");
                    }

                    if (x.Bounds.IntersectsWith(playerPb.Bounds))// Se gli invaders collidono con il player viene mostrato il messaggio di game over
                    {
                        gameOver("Sei stato ucciso dagli Invaders. Ora il mondo verrà conquistato dagli invasori.");
                    }

                    foreach (Control y in this.Controls) // per ogni y
                    {
                        if (y is PictureBox && (string)y.Tag == "proiettile") // Se y è una PictureBox e il tag è proiettili e quindi y è un proiettile
                        {
                            if (y.Bounds.IntersectsWith(x.Bounds)) // Se il proiettile collide con l'invaders allora sia il proiettile che il nemico vengono rimossi e il punteggio viene incrementato di uno 
                            {
                                esplosione.Play();
                                this.Controls.Remove(x);
                                this.Controls.Remove(y);
                                punteggio ++;
                                sparo = false;
                            }
                        }
                    }
                }
                if (x is PictureBox && (string)x.Tag == "proiettile") // Se è un proiettile 
                {
                    x.Top -= 40; // Viene spostato il proiettile 

                    if (x.Top < 15) // Se la distanza è maggiore di 15 il proiettile viene eliminato
                    {
                        this.Controls.Remove(x);
                        sparo = false;
                    }
                    if (punteggio > 15)
                    {
                        x.Top -= 25;
                    }
                }

                if (x is PictureBox && (string)x.Tag == "proiettileInvader") // Se x è un proiettile nemico 
                {
                    x.Top += 20; // viene spostato il proiettile

                    if (x.Top > 620) // Se la distanza è maggiore di 620 allora il proiettile viene rimosso
                    {
                        this.Controls.Remove(x);
                    }
                    if (x.Bounds.IntersectsWith(playerPb.Bounds)) // Se il proiettile colpisce il giocatore viene rimosso il proiettile e viene mostrato il messaggio di game over
                    {                   
                        this.Controls.Remove(x);   
                        gameOver("Sei stato ucciso dagli Invaders. Ora il mondo verrà conquistato dagli invasori.");
                    }
                }
            }
            if (punteggio > 7) // Se il punteggio è maggiore di 7 allora la velocità dei nemici viene impostata a 15
            {
                velocitàNemici = 15;
                if (punteggio > 20) // Se il punteggio è maggiore di 20 allore la velocità dei nemici viene impostata a 22
                {
                    velocitàNemici = 19;
                }
            }
            if (punteggio == Invaders.Length) // Se tutti gli inveders sono stati distrutti allora viene mostrato il messaggio di gameover
            {
                gameOver("Hai salvato il mondo!");
            }
        }

        private void setup()
        {
            PunteggioTxt.Text = "Punteggio: 0";
            punteggio = 0;
            isgameOver = false;

            timerProiettiliNemici = 200;
            velocitàNemici = 5;
            sparo = false;

            creazioneInvaders();
            gameTimer.Start();
        }

        private void gameOver(string message)
        {
            isgameOver = true;
            gameTimer.Stop();
            PunteggioTxt.Text = "Punteggio:  " + punteggio + "         " + message;
            utenteTxt.Visible = true;
        }

        private void elimina()
        {  
            foreach (PictureBox i in Invaders)
            {
                this.Controls.Remove(i);
            }
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "proiettile" || (string)x.Tag == "proiettileInvader")
                    {
                        this.Controls.Remove(x);
                    }
                }
            }
        }

        private void utenteTxt_MouseClick(object sender, MouseEventArgs e)
        {
            utenteTxt.Clear();
            salvaBtn.Visible = true; 
        }
        
        private void salvaBtn_Click(object sender, EventArgs e)
        {
            string file = @"Punteggi.txt"; // Viene creato il nome file
            string percorso = AppDomain.CurrentDomain.BaseDirectory + file; // Viene creato il percorso per salvare il file
            do // Fichè il giocatore non inserisce un nome utente vien richiesto 
            {
                if (utenteTxt.Text != "")
                {
                    table.Clear();
                    salvaBtn.Visible = false;
                    utenteTxt.Visible = false;
                    StreamWriter punteggi = new StreamWriter(percorso, true); // Vengono scritti i punteggi e i nomi utenti
                    punteggi.WriteLine(utenteTxt.Text + "  -  " + punteggio);
                    punteggi.Close();
                    MessageBox.Show("Punteggio salvato con successo");
                    ClassificaDGV.Visible = true;
                    ClassificaDGV.Enabled = true;

                    // Vengono aggiunti Nome Utente e Punteggio nella classifica dentro il Data grid View
                    string [] linee = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + file);
                    string [] values;
                    for (int i = 0; i < linee.Length; i++)
                    {
                        values = linee[i].ToString().Split('-'); // Viene messo nell'array values il contenuto di linee
                        string[] righe = new string[values.Length];

                        for (int j = 0; j < values.Length; j++)
                        {
                            righe[j] = values[j].Trim();/* Viene messo nell'array righe il contenuto di values e vengono poi messo nel DGV e i contenuti separati da "-" vengon messi in due colonne separate, 
                                                        quindi il contenuto che c'è prima di "-" verrà messo nella colonna del Nome, mentre il contenuto che si trova dopo di "-" verrà scritto nella colonna del punteggio*/
                        }

                        table.Rows.Add(righe);
                    }
                    break;
                }
                else
                {
                    MessageBox.Show("Inserisci un nome utente");
                }
            }
            while (utenteTxt.Text != "");
            ricominciareBtn.Visible = true;
            ricominciareBtn.Enabled = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // il pulsante "nuova partita?" permette di fare una nuova partita
            elimina();
            utenteTxt.Visible = false;
            salvaBtn.Visible = false;
            ricominciareBtn.Visible = false;
            ricominciareBtn.Enabled = false;
            playerPb.Visible = true;
            ClassificaDGV.Visible = false;
            ClassificaDGV.Enabled = false;
            PunteggioTxt.Visible = true;
            utenteTxt.Text = "Inserisci il tuo nome utente";
            playerPb.Left = 370;
            setup();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Vengono create le due colonne per il Nome Utente e il Punteggio
            table.Columns.Add("Nome Utente", typeof(string));
            table.Columns.Add("Punteggio", typeof(int));
            ClassificaDGV.DataSource = table;
        }

        private void creazioneProiettili(string bulletTag)
        {
            PictureBox proiettili = new PictureBox(); // Viene creata una PicturBox 
            proiettili.Image = Properties.Resources.bullet; // L'immagine della picturBox sarà il proiettile 
            proiettili.Size = new Size(5, 20); // Viene impostata la grandezza della PicturBox
            proiettili.Tag = bulletTag;
            proiettili.Left = playerPb.Left + playerPb.Width / 2; // Viene impostata da dove partirà il proiettile al livello di asse x

            if ((string)proiettili.Tag == "proiettile")
            {
                proiettili.Top = playerPb.Top - 20;
                sparoSuono.Play();
            }
            else if ((string)proiettili.Tag == "proiettileInvader")
            {
                proiettili.Top = -100;
                sparoSuono.Play();
            }

            this.Controls.Add(proiettili);
        }
    }
}
