namespace SchoolworkOrganizer
{
    partial class HomePanel
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
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            panel3 = new Panel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            todayTable = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            tabPage2 = new TabPage();
            nextWeekTable = new DataGridView();
            ActivityName = new DataGridViewTextBoxColumn();
            Subject = new DataGridViewTextBoxColumn();
            DueDate = new DataGridViewTextBoxColumn();
            panel4 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)todayTable).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nextWeekTable).BeginInit();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel1, 1, 0);
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1280, 720);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(643, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(634, 354);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(tabControl1);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(634, 354);
            panel3.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 64);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(634, 290);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = SystemColors.Control;
            tabPage1.Controls.Add(todayTable);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(626, 262);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Today";
            // 
            // todayTable
            // 
            todayTable.AllowUserToAddRows = false;
            todayTable.AllowUserToDeleteRows = false;
            todayTable.AllowUserToResizeRows = false;
            todayTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            todayTable.BackgroundColor = Color.FromArgb(65, 78, 101);
            todayTable.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(43, 49, 65);
            dataGridViewCellStyle7.Font = new Font("Roboto Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = Color.FromArgb(231, 231, 231);
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            todayTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            todayTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            todayTable.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3 });
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(65, 78, 101);
            dataGridViewCellStyle8.Font = new Font("Roboto Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(231, 231, 231);
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(52, 63, 82);
            dataGridViewCellStyle8.SelectionForeColor = Color.FromArgb(95, 192, 170);
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            todayTable.DefaultCellStyle = dataGridViewCellStyle8;
            todayTable.Dock = DockStyle.Fill;
            todayTable.EnableHeadersVisualStyles = false;
            todayTable.GridColor = Color.FromArgb(65, 78, 101);
            todayTable.Location = new Point(3, 3);
            todayTable.Margin = new Padding(0);
            todayTable.MultiSelect = false;
            todayTable.Name = "todayTable";
            todayTable.ReadOnly = true;
            todayTable.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = SystemColors.Control;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            todayTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            todayTable.RowHeadersVisible = false;
            todayTable.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            todayTable.Size = new Size(620, 256);
            todayTable.TabIndex = 8;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Activity";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Subject";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Due Time";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = SystemColors.Control;
            tabPage2.Controls.Add(nextWeekTable);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(0);
            tabPage2.Name = "tabPage2";
            tabPage2.Size = new Size(626, 262);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Next Week";
            // 
            // nextWeekTable
            // 
            nextWeekTable.AllowUserToAddRows = false;
            nextWeekTable.AllowUserToDeleteRows = false;
            nextWeekTable.AllowUserToResizeRows = false;
            nextWeekTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            nextWeekTable.BackgroundColor = Color.FromArgb(65, 78, 101);
            nextWeekTable.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = Color.FromArgb(43, 49, 65);
            dataGridViewCellStyle10.Font = new Font("Roboto Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle10.ForeColor = Color.FromArgb(231, 231, 231);
            dataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            nextWeekTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            nextWeekTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            nextWeekTable.Columns.AddRange(new DataGridViewColumn[] { ActivityName, Subject, DueDate });
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = Color.FromArgb(65, 78, 101);
            dataGridViewCellStyle11.Font = new Font("Roboto Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle11.ForeColor = Color.FromArgb(231, 231, 231);
            dataGridViewCellStyle11.SelectionBackColor = Color.FromArgb(52, 63, 82);
            dataGridViewCellStyle11.SelectionForeColor = Color.FromArgb(95, 192, 170);
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.False;
            nextWeekTable.DefaultCellStyle = dataGridViewCellStyle11;
            nextWeekTable.Dock = DockStyle.Fill;
            nextWeekTable.EnableHeadersVisualStyles = false;
            nextWeekTable.GridColor = Color.FromArgb(65, 78, 101);
            nextWeekTable.Location = new Point(0, 0);
            nextWeekTable.Margin = new Padding(0);
            nextWeekTable.MultiSelect = false;
            nextWeekTable.Name = "nextWeekTable";
            nextWeekTable.ReadOnly = true;
            nextWeekTable.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = SystemColors.Control;
            dataGridViewCellStyle12.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle12.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
            nextWeekTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            nextWeekTable.RowHeadersVisible = false;
            nextWeekTable.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            nextWeekTable.Size = new Size(626, 262);
            nextWeekTable.TabIndex = 7;
            // 
            // ActivityName
            // 
            ActivityName.HeaderText = "Activity";
            ActivityName.Name = "ActivityName";
            ActivityName.ReadOnly = true;
            // 
            // Subject
            // 
            Subject.HeaderText = "Subject";
            Subject.Name = "Subject";
            Subject.ReadOnly = true;
            // 
            // DueDate
            // 
            DueDate.HeaderText = "Due Date";
            DueDate.Name = "DueDate";
            DueDate.ReadOnly = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(label1);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(634, 64);
            panel4.TabIndex = 0;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(634, 64);
            label1.TabIndex = 54;
            label1.Text = "Activities Due";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(634, 354);
            panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(202, 158);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // HomePanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(5, 3, 5, 3);
            Name = "HomePanel";
            Size = new Size(1280, 720);
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)todayTable).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nextWeekTable).EndInit();
            panel4.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Panel panel3;
        private Panel panel4;
        private Label label1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView nextWeekTable;
        private DataGridViewTextBoxColumn ActivityName;
        private DataGridViewTextBoxColumn Subject;
        private DataGridViewTextBoxColumn DueDate;
        private DataGridView todayTable;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}