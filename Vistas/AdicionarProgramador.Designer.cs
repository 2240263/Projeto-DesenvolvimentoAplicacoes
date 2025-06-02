namespace iTasks.Vistas
{
    partial class AdicionarProgramador
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
            this.label11 = new System.Windows.Forms.Label();
            this.cbGestorProg = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btGravarProg = new System.Windows.Forms.Button();
            this.txtPasswordProg = new System.Windows.Forms.TextBox();
            this.cbNivelProg = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUsernameProg = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNomeProg = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.txtIdProg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(36, 360);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 20);
            this.label11.TabIndex = 57;
            this.label11.Text = "Gestor:";
            // 
            // cbGestorProg
            // 
            this.cbGestorProg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGestorProg.FormattingEnabled = true;
            this.cbGestorProg.Location = new System.Drawing.Point(40, 384);
            this.cbGestorProg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbGestorProg.Name = "cbGestorProg";
            this.cbGestorProg.Size = new System.Drawing.Size(300, 28);
            this.cbGestorProg.TabIndex = 56;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 294);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 20);
            this.label6.TabIndex = 55;
            this.label6.Text = "Nível de Experiência:";
            // 
            // btGravarProg
            // 
            this.btGravarProg.Location = new System.Drawing.Point(38, 441);
            this.btGravarProg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btGravarProg.Name = "btGravarProg";
            this.btGravarProg.Size = new System.Drawing.Size(132, 35);
            this.btGravarProg.TabIndex = 49;
            this.btGravarProg.Text = "Ok";
            this.btGravarProg.UseVisualStyleBackColor = true;
            this.btGravarProg.Click += new System.EventHandler(this.btOKProg_Click);
            // 
            // txtPasswordProg
            // 
            this.txtPasswordProg.Location = new System.Drawing.Point(40, 251);
            this.txtPasswordProg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPasswordProg.Name = "txtPasswordProg";
            this.txtPasswordProg.Size = new System.Drawing.Size(300, 26);
            this.txtPasswordProg.TabIndex = 53;
            this.txtPasswordProg.UseSystemPasswordChar = true;
            // 
            // cbNivelProg
            // 
            this.cbNivelProg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNivelProg.FormattingEnabled = true;
            this.cbNivelProg.Location = new System.Drawing.Point(40, 319);
            this.cbNivelProg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbNivelProg.Name = "cbNivelProg";
            this.cbNivelProg.Size = new System.Drawing.Size(300, 28);
            this.cbNivelProg.TabIndex = 54;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 226);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 20);
            this.label7.TabIndex = 52;
            this.label7.Text = "Password:";
            // 
            // txtUsernameProg
            // 
            this.txtUsernameProg.Location = new System.Drawing.Point(40, 189);
            this.txtUsernameProg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUsernameProg.Name = "txtUsernameProg";
            this.txtUsernameProg.Size = new System.Drawing.Size(300, 26);
            this.txtUsernameProg.TabIndex = 51;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 164);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 20);
            this.label8.TabIndex = 50;
            this.label8.Text = "Username:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 35);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 20);
            this.label9.TabIndex = 45;
            this.label9.Text = "Id:";
            // 
            // txtNomeProg
            // 
            this.txtNomeProg.Location = new System.Drawing.Point(40, 129);
            this.txtNomeProg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNomeProg.Name = "txtNomeProg";
            this.txtNomeProg.Size = new System.Drawing.Size(300, 26);
            this.txtNomeProg.TabIndex = 48;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 104);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 20);
            this.label10.TabIndex = 47;
            this.label10.Text = "Nome:";
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(195, 441);
            this.buttonCancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(132, 35);
            this.buttonCancelar.TabIndex = 58;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // txtIdProg
            // 
            this.txtIdProg.AutoSize = true;
            this.txtIdProg.Location = new System.Drawing.Point(37, 69);
            this.txtIdProg.Name = "txtIdProg";
            this.txtIdProg.Size = new System.Drawing.Size(0, 20);
            this.txtIdProg.TabIndex = 59;
            // 
            // AdicionarProgramador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 514);
            this.Controls.Add(this.txtIdProg);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbGestorProg);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btGravarProg);
            this.Controls.Add(this.txtPasswordProg);
            this.Controls.Add(this.cbNivelProg);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtUsernameProg);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtNomeProg);
            this.Controls.Add(this.label10);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AdicionarProgramador";
            this.Text = "AdicionarProgramador";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbGestorProg;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btGravarProg;
        private System.Windows.Forms.TextBox txtPasswordProg;
        private System.Windows.Forms.ComboBox cbNivelProg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUsernameProg;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNomeProg;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Label txtIdProg;
    }
}