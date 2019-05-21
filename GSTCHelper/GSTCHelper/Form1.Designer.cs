namespace GSTCHelper
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbOriginalBox = new System.Windows.Forms.RichTextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.rtbFinallBox = new System.Windows.Forms.RichTextBox();
            this.btnDESEncode = new System.Windows.Forms.Button();
            this.btnDESDecode = new System.Windows.Forms.Button();
            this.btnFunc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbOriginalBox
            // 
            this.rtbOriginalBox.Location = new System.Drawing.Point(89, 39);
            this.rtbOriginalBox.Name = "rtbOriginalBox";
            this.rtbOriginalBox.Size = new System.Drawing.Size(1721, 310);
            this.rtbOriginalBox.TabIndex = 0;
            this.rtbOriginalBox.Text = "";
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(108, 384);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(151, 76);
            this.btnEncrypt.TabIndex = 1;
            this.btnEncrypt.Text = "加密";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(332, 384);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(151, 76);
            this.btnDecrypt.TabIndex = 2;
            this.btnDecrypt.Text = "解密";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // rtbFinallBox
            // 
            this.rtbFinallBox.Location = new System.Drawing.Point(89, 488);
            this.rtbFinallBox.Name = "rtbFinallBox";
            this.rtbFinallBox.Size = new System.Drawing.Size(1721, 378);
            this.rtbFinallBox.TabIndex = 3;
            this.rtbFinallBox.Text = "";
            // 
            // btnDESEncode
            // 
            this.btnDESEncode.Location = new System.Drawing.Point(537, 384);
            this.btnDESEncode.Name = "btnDESEncode";
            this.btnDESEncode.Size = new System.Drawing.Size(151, 76);
            this.btnDESEncode.TabIndex = 4;
            this.btnDESEncode.Text = "DES加密";
            this.btnDESEncode.UseVisualStyleBackColor = true;
            this.btnDESEncode.Click += new System.EventHandler(this.btnDESEncode_Click);
            // 
            // btnDESDecode
            // 
            this.btnDESDecode.Location = new System.Drawing.Point(755, 384);
            this.btnDESDecode.Name = "btnDESDecode";
            this.btnDESDecode.Size = new System.Drawing.Size(151, 76);
            this.btnDESDecode.TabIndex = 5;
            this.btnDESDecode.Text = "DES解密";
            this.btnDESDecode.UseVisualStyleBackColor = true;
            this.btnDESDecode.Click += new System.EventHandler(this.btnDESDecode_Click);
            // 
            // btnFunc
            // 
            this.btnFunc.Location = new System.Drawing.Point(953, 384);
            this.btnFunc.Name = "btnFunc";
            this.btnFunc.Size = new System.Drawing.Size(151, 76);
            this.btnFunc.TabIndex = 6;
            this.btnFunc.Text = "string转byte";
            this.btnFunc.UseVisualStyleBackColor = true;
            this.btnFunc.Click += new System.EventHandler(this.btnFunc_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1894, 911);
            this.Controls.Add(this.btnFunc);
            this.Controls.Add(this.btnDESDecode);
            this.Controls.Add(this.btnDESEncode);
            this.Controls.Add(this.rtbFinallBox);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.rtbOriginalBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbOriginalBox;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.RichTextBox rtbFinallBox;
        private System.Windows.Forms.Button btnDESEncode;
        private System.Windows.Forms.Button btnDESDecode;
        private System.Windows.Forms.Button btnFunc;
    }
}

