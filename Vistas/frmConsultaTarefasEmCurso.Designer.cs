namespace iTasks
{
    partial class frmConsultaTarefasEmCurso
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
            this.gvTarefasEmCurso = new System.Windows.Forms.DataGridView();
            this.btFechar = new System.Windows.Forms.Button();
            this.labelCorEmCurso = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvTarefasEmCurso)).BeginInit();
            this.SuspendLayout();
            // 
            // gvTarefasEmCurso
            // 
            this.gvTarefasEmCurso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTarefasEmCurso.Location = new System.Drawing.Point(18, 19);
            this.gvTarefasEmCurso.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gvTarefasEmCurso.Name = "gvTarefasEmCurso";
            this.gvTarefasEmCurso.RowHeadersWidth = 51;
            this.gvTarefasEmCurso.Size = new System.Drawing.Size(1692, 608);
            this.gvTarefasEmCurso.TabIndex = 0;
            this.gvTarefasEmCurso.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvTarefasEmCurso_CellDoubleClick);
            this.gvTarefasEmCurso.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvTarefasEmCurso_CellFormatting_1);
            // 
            // btFechar
            // 
            this.btFechar.Location = new System.Drawing.Point(1554, 636);
            this.btFechar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(156, 35);
            this.btFechar.TabIndex = 30;
            this.btFechar.Text = "Fechar";
            this.btFechar.UseVisualStyleBackColor = true;
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // labelCorEmCurso
            // 
            this.labelCorEmCurso.AutoSize = true;
            this.labelCorEmCurso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCorEmCurso.Location = new System.Drawing.Point(39, 639);
            this.labelCorEmCurso.Name = "labelCorEmCurso";
            this.labelCorEmCurso.Size = new System.Drawing.Size(54, 22);
            this.labelCorEmCurso.TabIndex = 31;
            this.labelCorEmCurso.Text = "texto";
            // 
            // frmConsultaTarefasEmCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1778, 695);
            this.Controls.Add(this.labelCorEmCurso);
            this.Controls.Add(this.btFechar);
            this.Controls.Add(this.gvTarefasEmCurso);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmConsultaTarefasEmCurso";
            this.Text = "frmConsultaTarefasEmCurso";
            this.Load += new System.EventHandler(this.frmConsultaTarefasEmCurso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvTarefasEmCurso)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvTarefasEmCurso;
        private System.Windows.Forms.Button btFechar;
        private System.Windows.Forms.Label labelCorEmCurso;
    }
}