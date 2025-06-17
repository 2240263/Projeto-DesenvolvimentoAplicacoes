namespace iTasks
{
    partial class frmConsultarTarefasConcluidas
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
            this.btFechar = new System.Windows.Forms.Button();
            this.gvTarefasConcluidas = new System.Windows.Forms.DataGridView();
            this.labelCorConcluida = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvTarefasConcluidas)).BeginInit();
            this.SuspendLayout();
            // 
            // btFechar
            // 
            this.btFechar.Location = new System.Drawing.Point(1606, 661);
            this.btFechar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(156, 35);
            this.btFechar.TabIndex = 32;
            this.btFechar.Text = "Fechar";
            this.btFechar.UseVisualStyleBackColor = true;
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // gvTarefasConcluidas
            // 
            this.gvTarefasConcluidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTarefasConcluidas.Location = new System.Drawing.Point(18, 19);
            this.gvTarefasConcluidas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gvTarefasConcluidas.Name = "gvTarefasConcluidas";
            this.gvTarefasConcluidas.RowHeadersWidth = 51;
            this.gvTarefasConcluidas.Size = new System.Drawing.Size(1745, 621);
            this.gvTarefasConcluidas.TabIndex = 31;
            this.gvTarefasConcluidas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvTarefasConcluidas_CellDoubleClick);
            this.gvTarefasConcluidas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvTarefasConcluidas_CellFormatting);
            // 
            // labelCorConcluida
            // 
            this.labelCorConcluida.AutoSize = true;
            this.labelCorConcluida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCorConcluida.Location = new System.Drawing.Point(61, 661);
            this.labelCorConcluida.Name = "labelCorConcluida";
            this.labelCorConcluida.Size = new System.Drawing.Size(54, 22);
            this.labelCorConcluida.TabIndex = 33;
            this.labelCorConcluida.Text = "texto";
            // 
            // frmConsultarTarefasConcluidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1786, 779);
            this.Controls.Add(this.labelCorConcluida);
            this.Controls.Add(this.btFechar);
            this.Controls.Add(this.gvTarefasConcluidas);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmConsultarTarefasConcluidas";
            this.Text = "frmConsultarTarefasConcluidas";
            this.Load += new System.EventHandler(this.frmConsultarTarefasConcluidas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvTarefasConcluidas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btFechar;
        private System.Windows.Forms.DataGridView gvTarefasConcluidas;
        private System.Windows.Forms.Label labelCorConcluida;
    }
}