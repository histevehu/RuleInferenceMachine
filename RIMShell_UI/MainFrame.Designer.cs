namespace RuleInferenceMachine
{
    partial class MainFrame
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
            this.btn_importRule = new System.Windows.Forms.Button();
            this.btn_InputCon = new System.Windows.Forms.Button();
            this.btn_Inference = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_About = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_importRule
            // 
            this.btn_importRule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_importRule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_importRule.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_importRule.FlatAppearance.BorderSize = 3;
            this.btn_importRule.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btn_importRule.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.btn_importRule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_importRule.ForeColor = System.Drawing.Color.White;
            this.btn_importRule.Location = new System.Drawing.Point(286, 80);
            this.btn_importRule.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_importRule.Name = "btn_importRule";
            this.btn_importRule.Size = new System.Drawing.Size(319, 90);
            this.btn_importRule.TabIndex = 0;
            this.btn_importRule.Text = "Import/Create Rule File";
            this.btn_importRule.UseVisualStyleBackColor = false;
            this.btn_importRule.Click += new System.EventHandler(this.btn_importRule_Click);
            // 
            // btn_InputCon
            // 
            this.btn_InputCon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_InputCon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_InputCon.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_InputCon.FlatAppearance.BorderSize = 3;
            this.btn_InputCon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btn_InputCon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.btn_InputCon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_InputCon.ForeColor = System.Drawing.Color.White;
            this.btn_InputCon.Location = new System.Drawing.Point(286, 287);
            this.btn_InputCon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_InputCon.Name = "btn_InputCon";
            this.btn_InputCon.Size = new System.Drawing.Size(319, 90);
            this.btn_InputCon.TabIndex = 3;
            this.btn_InputCon.Text = "Add Condition";
            this.btn_InputCon.UseVisualStyleBackColor = false;
            this.btn_InputCon.Click += new System.EventHandler(this.btn_InputCon_Click);
            // 
            // btn_Inference
            // 
            this.btn_Inference.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Inference.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Inference.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_Inference.FlatAppearance.BorderSize = 3;
            this.btn_Inference.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btn_Inference.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.btn_Inference.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Inference.ForeColor = System.Drawing.Color.White;
            this.btn_Inference.Location = new System.Drawing.Point(286, 478);
            this.btn_Inference.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Inference.Name = "btn_Inference";
            this.btn_Inference.Size = new System.Drawing.Size(319, 90);
            this.btn_Inference.TabIndex = 4;
            this.btn_Inference.Text = "Inference";
            this.btn_Inference.UseVisualStyleBackColor = false;
            this.btn_Inference.Click += new System.EventHandler(this.btn_Inference_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 72F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label1.Location = new System.Drawing.Point(-60, -49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(539, 191);
            this.label1.TabIndex = 5;
            this.label1.Text = "Step 1";
            // 
            // btn_About
            // 
            this.btn_About.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_About.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_About.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_About.FlatAppearance.BorderSize = 3;
            this.btn_About.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btn_About.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.btn_About.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_About.ForeColor = System.Drawing.Color.White;
            this.btn_About.Location = new System.Drawing.Point(13, 619);
            this.btn_About.Margin = new System.Windows.Forms.Padding(4);
            this.btn_About.Name = "btn_About";
            this.btn_About.Size = new System.Drawing.Size(181, 58);
            this.btn_About.TabIndex = 6;
            this.btn_About.Text = "About RIM";
            this.btn_About.UseVisualStyleBackColor = false;
            this.btn_About.Click += new System.EventHandler(this.btn_About_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 72F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label2.Location = new System.Drawing.Point(-60, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(539, 191);
            this.label2.TabIndex = 7;
            this.label2.Text = "Step 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 72F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label3.Location = new System.Drawing.Point(-60, 349);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(539, 191);
            this.label3.TabIndex = 8;
            this.label3.Text = "Step 3";
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(683, 690);
            this.Controls.Add(this.btn_importRule);
            this.Controls.Add(this.btn_About);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Inference);
            this.Controls.Add(this.btn_InputCon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainFrame";
            this.Text = "Rule Inference Machine (RIM) Shell";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_importRule;
        private System.Windows.Forms.Button btn_InputCon;
        private System.Windows.Forms.Button btn_Inference;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_About;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

