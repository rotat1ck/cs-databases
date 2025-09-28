namespace DisconnectedMode
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            DataGrid = new DataGridView();
            InputBox = new TextBox();
            ExecButton = new Button();
            FillButton = new Button();
            ((System.ComponentModel.ISupportInitialize)DataGrid).BeginInit();
            SuspendLayout();
            // 
            // DataGrid
            // 
            DataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGrid.Location = new Point(12, 118);
            DataGrid.Name = "DataGrid";
            DataGrid.RowHeadersWidth = 51;
            DataGrid.Size = new Size(776, 320);
            DataGrid.TabIndex = 0;
            // 
            // InputBox
            // 
            InputBox.Location = new Point(12, 50);
            InputBox.Name = "InputBox";
            InputBox.Size = new Size(776, 27);
            InputBox.TabIndex = 1;
            // 
            // ExecButton
            // 
            ExecButton.Location = new Point(694, 83);
            ExecButton.Name = "ExecButton";
            ExecButton.Size = new Size(94, 29);
            ExecButton.TabIndex = 2;
            ExecButton.Text = "Exec";
            ExecButton.UseVisualStyleBackColor = true;
            ExecButton.Click += ExecButton_Click;
            // 
            // FillButton
            // 
            FillButton.Location = new Point(12, 83);
            FillButton.Name = "FillButton";
            FillButton.Size = new Size(94, 29);
            FillButton.TabIndex = 3;
            FillButton.Text = "Fill";
            FillButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(FillButton);
            Controls.Add(ExecButton);
            Controls.Add(InputBox);
            Controls.Add(DataGrid);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)DataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DataGrid;
        private TextBox InputBox;
        private Button ExecButton;
        private Button FillButton;
    }
}
