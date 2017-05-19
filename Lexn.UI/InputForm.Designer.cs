namespace Lexn.UI
{
    partial class InputForm
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
            this.lblInput = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(25, 63);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(36, 16);
            this.lblInput.TabIndex = 0;
            this.lblInput.Text = "Input";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(76, 60);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(100, 22);
            this.txtInput.TabIndex = 1;
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 145);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lblInput);
            this.Name = "InputForm";
            this.Text = "InputForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.TextBox txtInput;
    }
}