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
            this.txtNomeGestor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIdGestor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstListaGestores = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chkGereUtilizadores = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPasswordGestor = new System.Windows.Forms.TextBox();
            this.cbDepartamento = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsernameGestor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lstListaProgramadores = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btGravarProg = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btGravarGestor
            // 
            this.btGravarGestor.Location = new System.Drawing.Point(392, 348);
            this.btGravarGestor.Margin = new System.Windows.Forms.Padding(4);
            this.btGravarGestor.Name = "btGravarGestor";
            this.btGravarGestor.Size = new System.Drawing.Size(268, 28);
            this.btGravarGestor.TabIndex = 37;
            this.btGravarGestor.Text = "Gravar Dados";
            this.btGravarGestor.UseVisualStyleBackColor = true;
            this.btGravarGestor.Click += new System.EventHandler(this.btGravarGestor_Click);
            // 
            // txtNomeGestor
            // 
            this.txtNomeGestor.Location = new System.Drawing.Point(392, 98);
            this.txtNomeGestor.Margin = new System.Windows.Forms.Padding(4);
            this.txtNomeGestor.Name = "txtNomeGestor";
            this.txtNomeGestor.Size = new System.Drawing.Size(267, 22);
            this.txtNomeGestor.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(388, 78);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 35;
            this.label4.Text = "Nome:";
            // 
            // txtIdGestor
            // 
            this.txtIdGestor.Location = new System.Drawing.Point(392, 43);
            this.txtIdGestor.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdGestor.Name = "txtIdGestor";
            this.txtIdGestor.ReadOnly = true;
            this.txtIdGestor.Size = new System.Drawing.Size(81, 22);
            this.txtIdGestor.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(388, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 16);
            this.label1.TabIndex = 33;
            this.label1.Text = "Id:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstListaGestores);
            this.groupBox1.Location = new System.Drawing.Point(8, 23);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(365, 560);
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
            this.lstListaGestores.Margin = new System.Windows.Forms.Padding(4);
            this.lstListaGestores.Name = "lstListaGestores";
            this.lstListaGestores.Size = new System.Drawing.Size(357, 537);
            this.lstListaGestores.TabIndex = 0;
            this.lstListaGestores.SelectedIndexChanged += new System.EventHandler(this.lstListaGestores_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.chkGereUtilizadores);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btGravarGestor);
            this.groupBox2.Controls.Add(this.txtPasswordGestor);
            this.groupBox2.Controls.Add(this.cbDepartamento);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtUsernameGestor);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.txtIdGestor);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtNomeGestor);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(16, 14);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(681, 590);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gestores";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(392, 384);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(268, 28);
            this.button1.TabIndex = 44;
            this.button1.Text = "Atualizar Dados";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkGereUtilizadores
            // 
            this.chkGereUtilizadores.AutoSize = true;
            this.chkGereUtilizadores.Location = new System.Drawing.Point(392, 295);
            this.chkGereUtilizadores.Margin = new System.Windows.Forms.Padding(4);
            this.chkGereUtilizadores.Name = "chkGereUtilizadores";
            this.chkGereUtilizadores.Size = new System.Drawing.Size(133, 20);
            this.chkGereUtilizadores.TabIndex = 43;
            this.chkGereUtilizadores.Text = "Gere Utilizadores";
            this.chkGereUtilizadores.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(388, 230);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 42;
            this.label5.Text = "Departamento:";
            // 
            // txtPasswordGestor
            // 
            this.txtPasswordGestor.Location = new System.Drawing.Point(392, 196);
            this.txtPasswordGestor.Margin = new System.Windows.Forms.Padding(4);
            this.txtPasswordGestor.Name = "txtPasswordGestor";
            this.txtPasswordGestor.Size = new System.Drawing.Size(267, 22);
            this.txtPasswordGestor.TabIndex = 40;
            this.txtPasswordGestor.UseSystemPasswordChar = true;
            // 
            // cbDepartamento
            // 
            this.cbDepartamento.FormattingEnabled = true;
            this.cbDepartamento.Location = new System.Drawing.Point(392, 250);
            this.cbDepartamento.Margin = new System.Windows.Forms.Padding(4);
            this.cbDepartamento.Name = "cbDepartamento";
            this.cbDepartamento.Size = new System.Drawing.Size(267, 24);
            this.cbDepartamento.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(388, 176);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 39;
            this.label3.Text = "Password:";
            // 
            // txtUsernameGestor
            // 
            this.txtUsernameGestor.Location = new System.Drawing.Point(392, 146);
            this.txtUsernameGestor.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsernameGestor.Name = "txtUsernameGestor";
            this.txtUsernameGestor.Size = new System.Drawing.Size(267, 22);
            this.txtUsernameGestor.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(388, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 37;
            this.label2.Text = "Username:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lstListaProgramadores);
            this.groupBox4.Location = new System.Drawing.Point(-1, 23);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
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
            this.lstListaProgramadores.Margin = new System.Windows.Forms.Padding(4);
            this.lstListaProgramadores.Name = "lstListaProgramadores";
            this.lstListaProgramadores.Size = new System.Drawing.Size(366, 366);
            this.lstListaProgramadores.TabIndex = 0;
            this.lstListaProgramadores.SelectedIndexChanged += new System.EventHandler(this.lstListaProgramadores_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(52, 480);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(268, 28);
            this.button2.TabIndex = 45;
            this.button2.Text = "Editar ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonAtualizarProgramador_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.btGravarProg);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Location = new System.Drawing.Point(714, 14);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(414, 590);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Programadores";
            // 
            // btGravarProg
            // 
            this.btGravarProg.Location = new System.Drawing.Point(52, 429);
            this.btGravarProg.Margin = new System.Windows.Forms.Padding(4);
            this.btGravarProg.Name = "btGravarProg";
            this.btGravarProg.Size = new System.Drawing.Size(268, 28);
            this.btGravarProg.TabIndex = 37;
            this.btGravarProg.Text = "Criar";
            this.btGravarProg.UseVisualStyleBackColor = true;
            this.btGravarProg.Click += new System.EventHandler(this.btCriarProg_Click);
            // 
            // frmGereUtilizadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 620);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmGereUtilizadores";
            this.Text = "frmListaUtilizadores";
            this.Load += new System.EventHandler(this.frmGereUtilizadores_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btGravarGestor;
        private System.Windows.Forms.TextBox txtNomeGestor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIdGestor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstListaGestores;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPasswordGestor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsernameGestor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkGereUtilizadores;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbDepartamento;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lstListaProgramadores;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btGravarProg;
    }
}