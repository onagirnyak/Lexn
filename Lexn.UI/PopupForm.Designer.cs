﻿namespace Lexn.UI
{
    partial class PopupForm
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
            this.gridLexems = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridLexems)).BeginInit();
            this.SuspendLayout();
            // 
            // gridLexems
            // 
            this.gridLexems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLexems.Location = new System.Drawing.Point(16, 15);
            this.gridLexems.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridLexems.Name = "gridLexems";
            this.gridLexems.Size = new System.Drawing.Size(772, 559);
            this.gridLexems.TabIndex = 0;
            // 
            // PopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 588);
            this.Controls.Add(this.gridLexems);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PopupForm";
            this.Text = "PopupForm";
            ((System.ComponentModel.ISupportInitialize)(this.gridLexems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridLexems;
    }
}