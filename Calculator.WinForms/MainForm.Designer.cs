namespace Calculator.WinForms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtFieldA = new TextBox();
            txtFieldB = new TextBox();
            cboOperation = new ComboBox();
            btnCalculate = new Button();
            lblResult = new Label();
            lstHistory = new ListBox();
            lblMonthlyCount = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // txtFieldA
            // 
            txtFieldA.Location = new Point(100, 20);
            txtFieldA.Name = "txtFieldA";
            txtFieldA.Size = new Size(150, 23);
            txtFieldA.TabIndex = 4;
            // 
            // txtFieldB
            // 
            txtFieldB.Location = new Point(100, 120);
            txtFieldB.Name = "txtFieldB";
            txtFieldB.Size = new Size(150, 23);
            txtFieldB.TabIndex = 5;
            // 
            // cboOperation
            // 
            cboOperation.DropDownStyle = ComboBoxStyle.DropDownList;
            cboOperation.Location = new Point(100, 70);
            cboOperation.Name = "cboOperation";
            cboOperation.Size = new Size(150, 23);
            cboOperation.TabIndex = 6;
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(100, 170);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(150, 30);
            btnCalculate.TabIndex = 7;
            btnCalculate.Text = "Calculate";
            btnCalculate.Click += btnCalculate_Click;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblResult.Location = new Point(270, 170);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(0, 15);
            lblResult.TabIndex = 8;
            // 
            // lstHistory
            // 
            lstHistory.ItemHeight = 15;
            lstHistory.Location = new Point(20, 250);
            lstHistory.Name = "lstHistory";
            lstHistory.Size = new Size(540, 139);
            lstHistory.TabIndex = 9;
            lstHistory.SelectedIndexChanged += lstHistory_SelectedIndexChanged;
            // 
            // lblMonthlyCount
            // 
            lblMonthlyCount.AutoSize = true;
            lblMonthlyCount.Location = new Point(20, 410);
            lblMonthlyCount.Name = "lblMonthlyCount";
            lblMonthlyCount.Size = new Size(0, 15);
            lblMonthlyCount.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 0;
            label1.Text = "Field A:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 70);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 1;
            label2.Text = "Operation:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 120);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 2;
            label3.Text = "Field B:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 220);
            label4.Name = "label4";
            label4.Size = new Size(107, 15);
            label4.TabIndex = 3;
            label4.Text = "Recent Operations:";
            // 
            // MainForm
            // 
            ClientSize = new Size(584, 461);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(txtFieldA);
            Controls.Add(txtFieldB);
            Controls.Add(cboOperation);
            Controls.Add(btnCalculate);
            Controls.Add(lblResult);
            Controls.Add(lstHistory);
            Controls.Add(lblMonthlyCount);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gaia Calculator";
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox txtFieldA;
        private TextBox txtFieldB;
        private ComboBox cboOperation;
        private Button btnCalculate;
        private Label lblResult;
        private ListBox lstHistory;
        private Label lblMonthlyCount;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}