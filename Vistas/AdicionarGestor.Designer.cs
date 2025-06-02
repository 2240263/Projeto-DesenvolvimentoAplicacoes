namespace iTasks.Vistas
{
    partial class AdicionarGestor
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
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.btGravarProg = new System.Windows.Forms.Button();
            this.txtPasswordGestor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUsernameGestor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNomeGestor = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chkGereUtilizadores = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbDepartamento = new System.Windows.Forms.ComboBox();
            this.txtIdGestor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(184, 415);
            this.buttonCancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(132, 35);
            this.buttonCancelar.TabIndex = 72;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // btGravarProg
            // 
            this.btGravarProg.Location = new System.Drawing.Point(27, 415);
            this.btGravarProg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btGravarProg.Name = "btGravarProg";
            this.btGravarProg.Size = new System.Drawing.Size(132, 35);
            this.btGravarProg.TabIndex = 63;
            this.btGravarProg.Text = "Ok";
            this.btGravarProg.UseVisualStyleBackColor = true;
            this.btGravarProg.Click += new System.EventHandler(this.btOkGestor_Click);
            // 
            // txtPasswordGestor
            // 
            this.txtPasswordGestor.Location = new System.Drawing.Point(29, 225);
            this.txtPasswordGestor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPasswordGestor.Name = "txtPasswordGestor";
            this.txtPasswordGestor.Size = new System.Drawing.Size(300, 26);
            this.txtPasswordGestor.TabIndex = 67;
            this.txtPasswordGestor.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 200);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 20);
            this.label7.TabIndex = 66;
            this.label7.Text = "Password:";
            // 
            // txtUsernameGestor
            // 
            this.txtUsernameGestor.Location = new System.Drawing.Point(29, 162);
            this.txtUsernameGestor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUsernameGestor.Name = "txtUsernameGestor";
            this.txtUsernameGestor.Size = new System.Drawing.Size(300, 26);
            this.txtUsernameGestor.TabIndex = 65;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 138);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 20);
            this.label8.TabIndex = 64;
            this.label8.Text = "Username:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 9);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 20);
            this.label9.TabIndex = 59;
            this.label9.Text = "Id:";
            // 
            // txtNomeGestor
            // 
            this.txtNomeGestor.Location = new System.Drawing.Point(29, 102);
            this.txtNomeGestor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNomeGestor.Name = "txtNomeGestor";
            this.txtNomeGestor.Size = new System.Drawing.Size(300, 26);
            this.txtNomeGestor.TabIndex = 62;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 78);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 20);
            this.label10.TabIndex = 61;
            this.label10.Text = "Nome:";
            // 
            // chkGereUtilizadores
            // 
            this.chkGereUtilizadores.AutoSize = true;
            this.chkGereUtilizadores.Location = new System.Drawing.Point(30, 348);
            this.chkGereUtilizadores.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkGereUtilizadores.Name = "chkGereUtilizadores";
            this.chkGereUtilizadores.Size = new System.Drawing.Size(158, 24);
            this.chkGereUtilizadores.TabIndex = 75;
            this.chkGereUtilizadores.Text = "Gere Utilizadores";
            this.chkGereUtilizadores.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 266);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 20);
            this.label5.TabIndex = 74;
            this.label5.Text = "Departamento:";
            // 
            // cbDepartamento
            // 
            this.cbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartamento.FormattingEnabled = true;
            this.cbDepartamento.Location = new System.Drawing.Point(29, 291);
            this.cbDepartamento.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDepartamento.Name = "cbDepartamento";
            this.cbDepartamento.Size = new System.Drawing.Size(300, 28);
            this.cbDepartamento.TabIndex = 73;
            // 
            // txtIdGestor
            // 
            this.txtIdGestor.AutoSize = true;
            this.txtIdGestor.Location = new System.Drawing.Point(34, 40);
            this.txtIdGestor.Name = "txtIdGestor";
            this.txtIdGestor.Size = new System.Drawing.Size(17, 20);
            this.txtIdGestor.TabIndex = 76;
            this.txtIdGestor.Text = "  ";
            this.txtIdGestor.UseMnemonic = false;
            // 
            // AdicionarGestor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 482);
            this.Controls.Add(this.txtIdGestor);
            this.Controls.Add(this.chkGereUtilizadores);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbDepartamento);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.btGravarProg);
            this.Controls.Add(this.txtPasswordGestor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtUsernameGestor);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtNomeGestor);
            this.Controls.Add(this.label10);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AdicionarGestor";
            this.Text = "AdicionarGestor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button btGravarProg;
        private System.Windows.Forms.TextBox txtPasswordGestor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUsernameGestor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNomeGestor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkGereUtilizadores;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbDepartamento;
        private System.Windows.Forms.Label txtIdGestor;
    }
}