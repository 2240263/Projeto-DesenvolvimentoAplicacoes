namespace iTasks
{
    partial class frmGereTiposTarefas
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstLista = new System.Windows.Forms.ListBox();
            this.btGravar = new System.Windows.Forms.Button();
            this.ButEditar = new System.Windows.Forms.Button();
            this.ButApagar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstLista);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(365, 474);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de Tipos de Tarefas";
            // 
            // lstLista
            // 
            this.lstLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLista.FormattingEnabled = true;
            this.lstLista.ItemHeight = 16;
            this.lstLista.Location = new System.Drawing.Point(4, 19);
            this.lstLista.Margin = new System.Windows.Forms.Padding(4);
            this.lstLista.Name = "lstLista";
            this.lstLista.Size = new System.Drawing.Size(357, 451);
            this.lstLista.TabIndex = 0;
         
            // 
            // btGravar
            // 
            this.btGravar.Location = new System.Drawing.Point(422, 150);
            this.btGravar.Margin = new System.Windows.Forms.Padding(4);
            this.btGravar.Name = "btGravar";
            this.btGravar.Size = new System.Drawing.Size(185, 28);
            this.btGravar.TabIndex = 31;
            this.btGravar.Text = "Criar";
            this.btGravar.UseVisualStyleBackColor = true;
            this.btGravar.Click += new System.EventHandler(this.btCriarTT_Click);
            // 
            // ButEditar
            // 
            this.ButEditar.Location = new System.Drawing.Point(422, 216);
            this.ButEditar.Margin = new System.Windows.Forms.Padding(4);
            this.ButEditar.Name = "ButEditar";
            this.ButEditar.Size = new System.Drawing.Size(185, 28);
            this.ButEditar.TabIndex = 32;
            this.ButEditar.Text = "Editar";
            this.ButEditar.UseVisualStyleBackColor = true;
            // 
            // ButApagar
            // 
            this.ButApagar.Location = new System.Drawing.Point(422, 275);
            this.ButApagar.Margin = new System.Windows.Forms.Padding(4);
            this.ButApagar.Name = "ButApagar";
            this.ButApagar.Size = new System.Drawing.Size(185, 28);
            this.ButApagar.TabIndex = 33;
            this.ButApagar.Text = "Apagar";
            this.ButApagar.UseVisualStyleBackColor = true;
            this.ButApagar.Click += new System.EventHandler(this.ButApagar_Click);
            // 
            // frmGereTiposTarefas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 497);
            this.Controls.Add(this.ButApagar);
            this.Controls.Add(this.ButEditar);
            this.Controls.Add(this.btGravar);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmGereTiposTarefas";
            this.Text = "frmGereTiposTarefas";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstLista;
        private System.Windows.Forms.Button btGravar;
        private System.Windows.Forms.Button ButEditar;
        private System.Windows.Forms.Button ButApagar;
    }
}