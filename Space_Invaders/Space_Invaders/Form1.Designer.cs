namespace Space_Invaders
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.nuovaPartitaBtn = new System.Windows.Forms.Button();
            this.RegoleBtn = new System.Windows.Forms.Button();
            this.PunteggioTxt = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.playerPb = new System.Windows.Forms.PictureBox();
            this.utenteTxt = new System.Windows.Forms.TextBox();
            this.salvaBtn = new System.Windows.Forms.Button();
            this.ricominciareBtn = new System.Windows.Forms.Button();
            this.ClassificaDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.playerPb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClassificaDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // nuovaPartitaBtn
            // 
            this.nuovaPartitaBtn.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.nuovaPartitaBtn, "nuovaPartitaBtn");
            this.nuovaPartitaBtn.Name = "nuovaPartitaBtn";
            this.nuovaPartitaBtn.UseVisualStyleBackColor = false;
            this.nuovaPartitaBtn.Click += new System.EventHandler(this.button1_Click);
            this.nuovaPartitaBtn.MouseHover += new System.EventHandler(this.nuovaPartitaBtn_MouseHover);
            // 
            // RegoleBtn
            // 
            this.RegoleBtn.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.RegoleBtn, "RegoleBtn");
            this.RegoleBtn.Name = "RegoleBtn";
            this.RegoleBtn.UseVisualStyleBackColor = false;
            this.RegoleBtn.Click += new System.EventHandler(this.RegoleBtn_Click);
            this.RegoleBtn.MouseHover += new System.EventHandler(this.RegoleBtn_MouseHover);
            // 
            // PunteggioTxt
            // 
            resources.ApplyResources(this.PunteggioTxt, "PunteggioTxt");
            this.PunteggioTxt.ForeColor = System.Drawing.Color.Yellow;
            this.PunteggioTxt.Name = "PunteggioTxt";
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.mainGameTimer);
            // 
            // playerPb
            // 
            this.playerPb.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.playerPb, "playerPb");
            this.playerPb.Name = "playerPb";
            this.playerPb.TabStop = false;
            // 
            // utenteTxt
            // 
            resources.ApplyResources(this.utenteTxt, "utenteTxt");
            this.utenteTxt.Name = "utenteTxt";
            this.utenteTxt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.utenteTxt_MouseClick);
            // 
            // salvaBtn
            // 
            this.salvaBtn.BackColor = System.Drawing.Color.Black;
            this.salvaBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.salvaBtn, "salvaBtn");
            this.salvaBtn.Name = "salvaBtn";
            this.salvaBtn.UseVisualStyleBackColor = false;
            this.salvaBtn.Click += new System.EventHandler(this.salvaBtn_Click);
            // 
            // ricominciareBtn
            // 
            this.ricominciareBtn.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.ricominciareBtn, "ricominciareBtn");
            this.ricominciareBtn.Name = "ricominciareBtn";
            this.ricominciareBtn.UseVisualStyleBackColor = false;
            this.ricominciareBtn.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // ClassificaDGV
            // 
            this.ClassificaDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ClassificaDGV.BackgroundColor = System.Drawing.Color.Black;
            this.ClassificaDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ClassificaDGV.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.ClassificaDGV, "ClassificaDGV");
            this.ClassificaDGV.Name = "ClassificaDGV";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.ClassificaDGV.RowsDefaultCellStyle = dataGridViewCellStyle2;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.ricominciareBtn);
            this.Controls.Add(this.salvaBtn);
            this.Controls.Add(this.utenteTxt);
            this.Controls.Add(this.PunteggioTxt);
            this.Controls.Add(this.playerPb);
            this.Controls.Add(this.RegoleBtn);
            this.Controls.Add(this.nuovaPartitaBtn);
            this.Controls.Add(this.ClassificaDGV);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.playerPb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClassificaDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button nuovaPartitaBtn;
        private System.Windows.Forms.Button RegoleBtn;
        private System.Windows.Forms.PictureBox playerPb;
        private System.Windows.Forms.Label PunteggioTxt;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.TextBox utenteTxt;
        private System.Windows.Forms.Button salvaBtn;
        private System.Windows.Forms.Button ricominciareBtn;
        private System.Windows.Forms.DataGridView ClassificaDGV;
    }
}

