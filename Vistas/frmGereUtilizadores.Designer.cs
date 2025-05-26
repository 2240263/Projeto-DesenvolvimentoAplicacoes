namespace iTasks
{
    partial class frmGereUtilizadores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btGravarGestor = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstListaGestores = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonApagarGestor = new System.Windows.Forms.Button();
            this.buttonEditarGestor = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lstListaProgramadores = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonApagarProg = new System.Windows.Forms.Button();
            this.btGravarProg = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btGravarGestor
            // 
            this.btGravarGestor.Location = new System.Drawing.Point(49, 430);
            this.btGravarGestor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btGravarGestor.Name = "btGravarGestor";
            this.btGravarGestor.Size = new System.Drawing.Size(268, 28);
            this.btGravarGestor.TabIndex = 37;
            this.btGravarGestor.Text = "Criar";
            this.btGravarGestor.UseVisualStyleBackColor = true;
            this.btGravarGestor.Click += new System.EventHandler(this.btGravarGestor_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstListaGestores);
            this.groupBox1.Location = new System.Drawing.Point(8, 23);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(365, 385);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista";
            // 
            // lstListaGestores
            // 
            this.lstListaGestores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstListaGestores.FormattingEnabled = true;
            this.lstListaGestores.ItemHeight = 16;
            this.lstListaGestores.Location = new System.Drawing.Point(4, 19);
            this.lstListaGestores.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstListaGestores.Name = "lstListaGestores";
            this.lstListaGestores.Size = new System.Drawing.Size(357, 362);
            this.lstListaGestores.TabIndex = 0;
            this.lstListaGestores.SelectedIndexChanged += new System.EventHandler(this.lstListaGestores_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonApagarGestor);
            this.groupBox2.Controls.Add(this.buttonEditarGestor);
            this.groupBox2.Controls.Add(this.btGravarGestor);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Location = new System.Drawing.Point(16, 14);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(404, 571);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gestores";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // buttonApagarGestor
            // 
            this.buttonApagarGestor.Location = new System.Drawing.Point(49, 519);
            this.buttonApagarGestor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonApagarGestor.Name = "buttonApagarGestor";
            this.buttonApagarGestor.Size = new System.Drawing.Size(268, 28);
            this.buttonApagarGestor.TabIndex = 45;
            this.buttonApagarGestor.Text = "Apagar";
            this.buttonApagarGestor.UseVisualStyleBackColor = true;
            this.buttonApagarGestor.Click += new System.EventHandler(this.buttonApagarGestor_Click);
            // 
            // buttonEditarGestor
            // 
            this.buttonEditarGestor.Location = new System.Drawing.Point(49, 475);
            this.buttonEditarGestor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonEditarGestor.Name = "buttonEditarGestor";
            this.buttonEditarGestor.Size = new System.Drawing.Size(268, 28);
            this.buttonEditarGestor.TabIndex = 44;
            this.buttonEditarGestor.Text = "Editar";
            this.buttonEditarGestor.UseVisualStyleBackColor = true;
            this.buttonEditarGestor.Click += new System.EventHandler(this.BotaoEditarG);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lstListaProgramadores);
            this.groupBox4.Location = new System.Drawing.Point(-1, 23);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(374, 389);
            this.groupBox4.TabIndex = 32;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Lista";
            // 
            // lstListaProgramadores
            // 
            this.lstListaProgramadores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstListaProgramadores.FormattingEnabled = true;
            this.lstListaProgramadores.ItemHeight = 16;
            this.lstListaProgramadores.Location = new System.Drawing.Point(4, 19);
            this.lstListaProgramadores.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstListaProgramadores.Name = "lstListaProgramadores";
            this.lstListaProgramadores.Size = new System.Drawing.Size(366, 366);
            this.lstListaProgramadores.TabIndex = 0;
            this.lstListaProgramadores.SelectedIndexChanged += new System.EventHandler(this.lstListaProgramadores_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(65, 475);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(268, 28);
            this.button2.TabIndex = 45;
            this.button2.Text = "Editar ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonAtualizarProgramador_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonApagarProg);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.btGravarProg);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Location = new System.Drawing.Point(513, 14);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(414, 571);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Programadores";
            // 
            // buttonApagarProg
            // 
            this.buttonApagarProg.Location = new System.Drawing.Point(65, 517);
            this.buttonApagarProg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonApagarProg.Name = "buttonApagarProg";
            this.buttonApagarProg.Size = new System.Drawing.Size(268, 30);
            this.buttonApagarProg.TabIndex = 46;
            this.buttonApagarProg.Text = "Apagar ";
            this.buttonApagarProg.UseVisualStyleBackColor = true;
            this.buttonApagarProg.Click += new System.EventHandler(this.buttonApagarProg_Click);
            // 
            // btGravarProg
            // 
            this.btGravarProg.Location = new System.Drawing.Point(65, 430);
            this.btGravarProg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btGravarProg.Name = "btGravarProg";
            this.btGravarProg.Size = new System.Drawing.Size(268, 28);
            this.btGravarProg.TabIndex = 37;
            this.btGravarProg.Text = "Criar";
            this.btGravarProg.UseVisualStyleBackColor = true;
            this.btGravarProg.Click += new System.EventHandler(this.btCriarProg_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(8, 690);
            this.splitter1.TabIndex = 40;
            this.splitter1.TabStop = false;
            // 
            // frmGereUtilizadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 690);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmGereUtilizadores";
            this.Text = "frmListaUtilizadores";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btGravarGestor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonEditarGestor;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lstListaProgramadores;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btGravarProg;
        private System.Windows.Forms.ListBox lstListaGestores;
        private System.Windows.Forms.Button buttonApagarGestor;
        private System.Windows.Forms.Button buttonApagarProg;
        private System.Windows.Forms.Splitter splitter1;
    }
}