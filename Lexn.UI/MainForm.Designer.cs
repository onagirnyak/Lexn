using FastColoredTextBoxNS;

namespace Lexn.UI
{
    partial class LexnForm
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
            this.txtCode = new FastColoredTextBox();
            this.btnLexicalAnalyze = new System.Windows.Forms.Button();
            this.btnViewLexems = new System.Windows.Forms.Button();
            this.btnViewIdentifiers = new System.Windows.Forms.Button();
            this.btnViewConstants = new System.Windows.Forms.Button();
            this.btnViewErrors = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(12, 12);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(630, 385);
            this.txtCode.TabIndex = 0;
            this.txtCode.Text = "";
            this.txtCode.TextChanged += new System.EventHandler<TextChangedEventArgs>(this.txtCode_TextChanged);
            // 
            // btnLexicalAnalyze
            // 
            this.btnLexicalAnalyze.Location = new System.Drawing.Point(12, 412);
            this.btnLexicalAnalyze.Name = "btnLexicalAnalyze";
            this.btnLexicalAnalyze.Size = new System.Drawing.Size(87, 47);
            this.btnLexicalAnalyze.TabIndex = 1;
            this.btnLexicalAnalyze.Text = "Lexical analyze";
            this.btnLexicalAnalyze.UseVisualStyleBackColor = true;
            this.btnLexicalAnalyze.Click += new System.EventHandler(this.btnLexicalAnalyze_Click);
            // 
            // btnViewLexems
            // 
            this.btnViewLexems.Location = new System.Drawing.Point(105, 412);
            this.btnViewLexems.Name = "btnViewLexems";
            this.btnViewLexems.Size = new System.Drawing.Size(87, 47);
            this.btnViewLexems.TabIndex = 2;
            this.btnViewLexems.Text = "View lexems";
            this.btnViewLexems.UseVisualStyleBackColor = true;
            this.btnViewLexems.Click += new System.EventHandler(this.btnViewLexems_Click);
            // 
            // btnViewIdentifiers
            // 
            this.btnViewIdentifiers.Location = new System.Drawing.Point(198, 412);
            this.btnViewIdentifiers.Name = "btnViewIdentifiers";
            this.btnViewIdentifiers.Size = new System.Drawing.Size(87, 47);
            this.btnViewIdentifiers.TabIndex = 3;
            this.btnViewIdentifiers.Text = "View identifiers";
            this.btnViewIdentifiers.UseVisualStyleBackColor = true;
            this.btnViewIdentifiers.Click += new System.EventHandler(this.btnViewIdentifiers_Click);
            // 
            // btnViewConstants
            // 
            this.btnViewConstants.Location = new System.Drawing.Point(291, 412);
            this.btnViewConstants.Name = "btnViewConstants";
            this.btnViewConstants.Size = new System.Drawing.Size(87, 47);
            this.btnViewConstants.TabIndex = 4;
            this.btnViewConstants.Text = "View constants";
            this.btnViewConstants.UseVisualStyleBackColor = true;
            this.btnViewConstants.Click += new System.EventHandler(this.btnViewConstants_Click);
            // 
            // btnViewErrors
            // 
            this.btnViewErrors.Location = new System.Drawing.Point(384, 412);
            this.btnViewErrors.Name = "btnViewErrors";
            this.btnViewErrors.Size = new System.Drawing.Size(87, 47);
            this.btnViewErrors.TabIndex = 5;
            this.btnViewErrors.Text = "View errors";
            this.btnViewErrors.UseVisualStyleBackColor = true;
            this.btnViewErrors.Click += new System.EventHandler(this.btnViewErrors_Click);
            // 
            // LexnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 471);
            this.Controls.Add(this.btnViewErrors);
            this.Controls.Add(this.btnViewConstants);
            this.Controls.Add(this.btnViewIdentifiers);
            this.Controls.Add(this.btnViewLexems);
            this.Controls.Add(this.btnLexicalAnalyze);
            this.Controls.Add(this.txtCode);
            this.Name = "LexnForm";
            this.Text = "Lexn";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LexnForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FastColoredTextBox txtCode;
        private System.Windows.Forms.Button btnLexicalAnalyze;
        private System.Windows.Forms.Button btnViewLexems;
        private System.Windows.Forms.Button btnViewIdentifiers;
        private System.Windows.Forms.Button btnViewConstants;
        private System.Windows.Forms.Button btnViewErrors;
    }
}

